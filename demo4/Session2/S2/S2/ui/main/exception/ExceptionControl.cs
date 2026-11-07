using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.data.models;
using S2.data.models.maps;
using S2.util;

namespace S2.controls
{
    /// <summary>
    /// Exception management (only for customs manager): view and manage exceptions.
    /// </summary>
    public partial class ExceptionControl : UserControl
    {
       

        private readonly List<ExceptionRow> allRows = new List<ExceptionRow>();
        private readonly List<ExceptionRow> filteredRows = new List<ExceptionRow>();
        private readonly ExceptionColumnMap colMap = new ExceptionColumnMap();

        public ExceptionControl()
        {
            InitializeComponent();


            initControl();
        }

        private void initControl()
        {
            initDataGridView();
        }

        public void loadData()
        {
            loadExceptionTypes();
            searchExceptions();
        }

        private void loadExceptionTypes()
        {
            using (var db = new S2DBEntities())
            {
                cb_exception_type.Items.Clear();
                cb_exception_type.Items.Add("All");
                var data = db.exception_type
                    .AsNoTracking()
                    .OrderBy(x => x.id)
                    .Select(x => x.type)
                    .ToList();

                cb_exception_type.Items.AddRange(data.ToArray());
            }
            cb_exception_type.SelectedIndex = 0;
        }

        private void initDataGridView()
        {
            dataGridView.Columns.Add(colMap.VOYAGE, "Voyage Number");
            dataGridView.Columns.Add(colMap.CONTAINER, "Container Number");
            dataGridView.Columns.Add(colMap.OWNER, "Cargo Owner");
            dataGridView.Columns.Add(colMap.HS_CODE, "HS Code");
            dataGridView.Columns.Add(colMap.HS_DESC, "HS Description");
            dataGridView.Columns.Add(colMap.TYPE, "Exception Type");
            dataGridView.Columns.Add(colMap.SUBMIT_TIME, "Submitted Time");
            dataGridView.Columns.Add(colMap.INSPECTOR, "Inspector");
            dataGridView.Columns.Add(colMap.STATUS, "Status");

            DataGridViewUtils gridUtil = new DataGridViewUtils();

            gridUtil.addLinkColumn(dataGridView, colMap.HANDLE, "Handle");
            gridUtil.addLinkColumn(dataGridView, colMap.SEIZE, "Seize");
            gridUtil.addLinkColumn(dataGridView, colMap.DETAIL, "View Detail");
        }

        private void btn_search_ex_Click(object sender, EventArgs e)
        {
            searchExceptions();
        }

        private void searchExceptions()
        {
            loadAllExceptions();
            filterExceptions();
            showExceptions();
        }

        private string getFilterValue(Control control)
        {
            string text = control.Text.Trim();
            return "All".Equals(text) ? "" : text;
        }

        private void loadAllExceptions()
        {
            allRows.Clear();

            using (var db = new S2DBEntities())
            {
                int approvedId = StatusUtils.getDeclarationId(db, StatusUtils.Approved);

                var data = db.security_check_exception
                    .AsNoTracking()
                    .Select(ex => new
                    {
                        ex.security_check_id,
                        voyageNumber = ex.security_check.container.voyage_number,
                        containerNumber = ex.security_check.container.container_number,
                        cargoOwner = ex.security_check.container.cargo_owner.username,
                        hsCode = ex.security_check.container.declarations
                            .Where(d => d.declaration_status_id == approvedId)
                            .OrderByDescending(d => d.declaration_time)
                            .Select(d => d.hs_code)
                            .FirstOrDefault(),
                        hsDescription = ex.security_check.container.declarations
                            .Where(d => d.declaration_status_id == approvedId)
                            .OrderByDescending(d => d.declaration_time)
                            .Select(d => d.harmonized_system.hs_description)
                            .FirstOrDefault(),
                        exceptionType = ex.exception_type.type,
                        ex.submit_time,
                        ex.inspector,
                        officerFirst = ex.customs_officer.first_name,
                        officerLast = ex.customs_officer.last_name,
                        status = ex.security_check.security_check_status.status
                    })
                    .ToList();

                foreach (var item in data)
                {
                    var displayStatus = getDisplayStatus(item.status);
                    if (displayStatus == null) continue;

                    string inspector = string.IsNullOrEmpty(item.officerFirst)
                        && string.IsNullOrEmpty(item.officerLast)
                        ? item.inspector
                        : (item.officerFirst + " " + item.officerLast).Trim();

                    var row = new ExceptionRow();
                    row.voyageNumber = item.voyageNumber;
                    row.containerNumber = item.containerNumber;
                    row.cargoOwner = item.cargoOwner;
                    row.hsCode = item.hsCode ?? "";
                    row.hsDescription = item.hsDescription ?? "";
                    row.exceptionType = item.exceptionType;
                    row.submitTime = item.submit_time ?? DateTime.MinValue;
                    row.inspector = inspector;
                    row.status = displayStatus;
                    row.securityCheckId = item.security_check_id;
                    row.isDeclarationDiscrepancy =
                        item.exceptionType == "Declaration Discrepancy";

                    allRows.Add(row);
                }
            }
        }

        private string getDisplayStatus(string status)
        {
            if (status == StatusUtils.Exception) return "Pending";
            if (status == StatusUtils.Handled) return "Handled";
            if (status == StatusUtils.Seized) return "Seized";
            return null;
        }

        private void filterExceptions()
        {
            string voyage = getFilterValue(tb_voyage_number);
            string container = getFilterValue(tb_conatiner_number);
            string owner = getFilterValue(tb_cargo_owner);
            string type = getFilterValue(cb_exception_type);

            // Filter + sort: Pending, Handled, Seized; same status by submit time ascending
            filteredRows.Clear();
            filteredRows.AddRange(allRows
                .Where(r => (voyage.Length == 0 ||
                        r.voyageNumber.IndexOf(voyage, StringComparison.OrdinalIgnoreCase) >= 0)
                    && (container.Length == 0 ||
                        r.containerNumber.IndexOf(container, StringComparison.OrdinalIgnoreCase) >= 0)
                    && (owner.Length == 0 ||
                        r.cargoOwner.IndexOf(owner, StringComparison.OrdinalIgnoreCase) >= 0)
                    && (type.Length == 0 || r.exceptionType == type))
                .OrderBy(r => r.status == "Pending" ? 0 : r.status == "Handled" ? 1 : 2)
                .ThenBy(r => r.submitTime));
        }

        private void showExceptions()
        {
            // Draw
            dataGridView.Rows.Clear();
            foreach (var row in filteredRows)
            {
                int index = dataGridView.Rows.Add(
                    row.voyageNumber,
                    row.containerNumber,
                    row.cargoOwner,
                    row.hsCode,
                    row.hsDescription,
                    row.exceptionType,
                    row.submitTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    row.inspector,
                    row.status,
                    "Handle",
                    "Seize",
                    "View Detail"
                );
                dataGridView.Rows[index].Tag = row;

                if (row.status != "Pending")
                {
                    // Handled / Seized: only View Detail
                    UiUtils.DisableCells(dataGridView.Rows[index], colMap.HANDLE, colMap.SEIZE);
                }
                else if (row.isDeclarationDiscrepancy)
                {
                    // Declaration discrepancy: Handle link only
                    UiUtils.DisableCells(dataGridView.Rows[index], colMap.SEIZE, colMap.DETAIL);
                }
                else
                {
                    // Other types: Seize link only
                    UiUtils.DisableCells(dataGridView.Rows[index], colMap.HANDLE,colMap.DETAIL);
                }
            }
        }

        private void dgv_exception_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView.Rows[e.RowIndex].Tag as ExceptionRow;
            if (row == null) return;

            if (e.ColumnIndex == dataGridView.Columns[colMap.SEIZE].Index)
            {
                seize(row);
            }
        }

        private void seize(ExceptionRow row)
        {
            if (!MsgUtils.Confirm("Are you sure to seize this container?")) return;

            using (var db = new S2DBEntities())
            {
                var check = db.security_check.FirstOrDefault(s => s.id == row.securityCheckId);
                if (check == null)
                {
                    MessageBox.Show("The security check record could not be found");
                    return;
                }
                using (var transaction = db.Database.BeginTransaction())
                {
                    StatusUtils.setSecurity(db, check, StatusUtils.Seized);
                    db.SaveChanges();
                    transaction.Commit();
                }
            }

            MessageBox.Show("The container has been seized");
            searchExceptions();
        }
    }
}
