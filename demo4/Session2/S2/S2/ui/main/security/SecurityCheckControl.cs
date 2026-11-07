using S2.data.db.model;
using S2.data.models;
using S2.data.models.maps;
using S2.ui;
using S2.ui.main.security;
using S2.util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace S2.controls
{

    public partial class SecurityCheckControl : UserControl
    {
        private readonly SecurityColumnMap colMap = new SecurityColumnMap();
        private VoyageControl selectedCard;
        private string currentVoyage = "";

        public SecurityCheckControl()
        {
            InitializeComponent();

            initDataGridView();

            refreshVoyage();
            initControl();
            initListener();
        }

        private void initControl()
        {
            lb_voyage_number_xxx.Text = "Voyage Number:";

            dtp_from.Value = DateTime.Today.AddMonths(-1);
            dtp_to.Value = DateTime.Today;


        }

        private void initListener()
        {
            tb_veyage_number.TextChanged += (s, e) => refreshVoyage();

            dtp_from.ValueChanged += (s, e) => refreshVoyage();
            dtp_to.ValueChanged += (s, e) => refreshVoyage();

            btn_from.Click += (s, e) => openCalendar(dtp_from);
            btn_to.Click += (s, e) => openCalendar(dtp_to);

            cb_security_check_status.SelectedIndexChanged += (s, e) => refreshGridData();
            cb_hs_code.TextChanged += (s, e) => refreshGridData();
            cb_cargo_owner_rating.SelectedIndexChanged += (s, e) => refreshGridData();
            cb_container_number.SelectedIndexChanged += (s, e) => refreshGridData();

            datagridview.CellClick += Datagridview_CellClick;
        }

        private void Datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName = datagridview.Columns[e.ColumnIndex].Name;
            if(columnName == colMap.REPORT)
            {
                SecurityRow row = datagridview.Rows[e.RowIndex].Tag as SecurityRow;

                new ReportExceptionForm(row, currentVoyage).Show();
            }
        }

        private void refreshVoyage()
        {
            DateTime from = dtp_from.Value.Date;
            DateTime to = dtp_to.Value.Date;
            DateTime toEnd = to.AddDays(1);

            if (to < from)
            {
                MessageBox.Show("The end date can not be earlier than the start date");
                return;
            }

            string keywordVeyageNumber = tb_veyage_number.Text.Trim();

            using (var db = new S2DBEntities())
            {
                var data = db.voyages
                    .AsNoTracking()
                    .Where(x => x.actual_arrival_time >= from
                    && x.actual_arrival_time < toEnd
                    && (keywordVeyageNumber.Length == 0 || x.voyage_number.Contains(keywordVeyageNumber))
                    && x.containers.Any(c => c.declarations.Any(
                        d => d.declaration_status.status == StatusUtils.Approved)))
                    .Select(x => new VoyageRow
                    {
                        number = x.voyage_number,
                        arrivalTime = x.actual_arrival_time.Value,
                        containerCount = x.containers.Count()
                    })
                    .ToList();

                flowpanel.Controls.Clear();
                foreach (var item in data)
                {
                    var card = new VoyageControl(this, item);
                    flowpanel.Controls.Add(card);
                }

                if(flowpanel.Controls.Count > 0)
                {
                    VoyageControl firstCard = flowpanel.Controls[0] as VoyageControl;

                    echoParentVoyage(firstCard, data[0].number);
                }
            }

        }




        public void loadData()
        {
            loadFilterOptions();
            refreshVoyage();
        }

        private void loadFilterOptions()
        {
            using (var db = new S2DBEntities())
            {
                var securityCheckStatusList = db.security_check_status
                    .AsNoTracking()
                    .OrderBy(x => x.id)
                    .Select(x => x.status)
                    .ToList();
                securityCheckStatusList.Add(StatusUtils.NotStarted);
                var hsCodeList = db.declarations
                    .AsNoTracking()
                    .Select(x => x.hs_code)
                    .Distinct()
                    .ToList();
                var cargoOwnerRatingList = db.cargo_owner_rating
                    .AsNoTracking()
                    .OrderBy(x => x.id)
                    .Select(x => x.rating)
                    .ToList();

                initComboBoxItems(cb_security_check_status, securityCheckStatusList);
                initComboBoxItems(cb_hs_code, hsCodeList);
                initComboBoxItems(cb_cargo_owner_rating, cargoOwnerRatingList);

            }
        }

        private static void initComboBoxItems(ComboBox combo, List<string> values)
        {
            combo.Items.Clear();

            combo.Items.Add("All");
            combo.Items.AddRange(values.ToArray());

            combo.SelectedIndex = 0;
        }

        private void openCalendar(DateTimePicker picker)
        {
            picker.Focus();
            SendKeys.Send("%{DOWN}");
        }

        private void initDataGridView()
        {

            DataGridViewUtils gridUtils = new DataGridViewUtils();

            gridUtils.addCheckBoxColumn(datagridview, colMap.CHECK, "");
            datagridview.Columns.Add(colMap.CONTAINER, "Container Number");
            datagridview.Columns.Add(colMap.HS_CODE, "HS Code");
            datagridview.Columns.Add(colMap.HS_DESC, "HS Description");
            datagridview.Columns.Add(colMap.OWNER, "Cargo Owner");
            datagridview.Columns.Add(colMap.RATING, "Cargo Owner Rating");
            datagridview.Columns.Add(colMap.STATUS, "Security Check Status");
            datagridview.Columns.Add(colMap.RISK, "Risk Score");

            gridUtils.addLinkColumn(datagridview, colMap.UNSEAL, "");
            gridUtils.addLinkColumn(datagridview, colMap.REPORT, "");
            gridUtils.addLinkColumn(datagridview, colMap.RELEASE, "");
        }

        private void refreshGridData()
        {

            using (var db = new S2DBEntities())
            {
                string status = getFilterValue(cb_security_check_status);
                string hs = getFilterValue(cb_hs_code);
                string rating = getFilterValue(cb_cargo_owner_rating);
                string container = getFilterValue(cb_container_number);
                DateTime historyStart = DateTime.Now.AddMonths(-12);

                var data = db.declarations
                    .Where(x => x.container.voyage_number == currentVoyage
                        && x.declaration_status.status == StatusUtils.Approved
                        && (x.harmonized_system.hs_code == hs || hs.Length == 0)
                        && (x.container.cargo_owner.cargo_owner_rating.rating == rating || rating.Length == 0)
                        && (x.container_number == container || container.Length == 0))
                    .Select(x => new
                    {
                        containerNumber = x.container.container_number,
                        hsCode = x.hs_code,
                        hsDescription = x.harmonized_system.hs_description,
                        cargoOwner = x.container.cargo_owner.username,
                        rating = x.container.cargo_owner.cargo_owner_rating.rating,
                        riskGrade = x.harmonized_system.risk_grade,
                        voyageNumber = x.container.voyage_number,

                        hasException = db.security_check_exception
                        .Any(e => e.submit_time >= historyStart
                            && e.security_check.container.cargo_owner_id == x.container.cargo_owner_id),

                        status = db.security_check
                            .Where(s => s.container_number == x.container_number)
                            .OrderByDescending(s => s.check_time)
                            .ThenByDescending(s => s.id)
                            .Select(s => s.security_check_status.status)
                            .FirstOrDefault() ?? StatusUtils.NotStarted
                    })
                    .ToList();

                var dataOfGrid = data
                    .Where(x => x.status != StatusUtils.Seized
                        && x.status != StatusUtils.Handled
                        && (status.Length == 0 || x.status == status))
                    .Select(x => new SecurityRow
                    {
                        containerNumber = x.containerNumber,
                        hsCode = x.hsCode,
                        hsDescription = x.hsDescription,
                        cargoOwner = x.cargoOwner,
                        rating = x.rating,
                        status = x.status,
                        voyageNumber = x.voyageNumber,
                        riskScore = RiskCalculator.Calculate(
                            x.rating,
                            x.riskGrade,
                            x.hasException)
                    })
                    .OrderBy(x => getStatusOrder(x.status))
                    .ToList();

                datagridview.Rows.Clear();

                foreach (var item in dataOfGrid)
                {
                    bool showCheck = false;
                    bool showUnseal = false;
                    bool showReport = false;
                    bool showRelease = false;
                    bool showRisk = true;

                    if (item.status == StatusUtils.InitialInspection)
                    {
                        showCheck = true;
                        showUnseal = true;
                        showReport = true;
                        showRelease = true;
                        if (item.riskScore >= 30)
                        {
                            showRelease = false;
                        }
                    }
                    else if (item.status == StatusUtils.UnsealingInspection)
                    {
                        showCheck = true;
                        showReport = true;
                        showRelease = true;
                        showUnseal = false;
                    }
                    else if (item.status == StatusUtils.Exception || item.status == StatusUtils.Released)
                    {
                        showRisk = false;
                        showUnseal = false;
                        showRelease = false;
                        showCheck = false;
                        showReport = false;
                    }


                    int index = datagridview.Rows.Add();
                    DataGridViewRow row = datagridview.Rows[index];

                    row.Cells[colMap.CONTAINER].Value = item.containerNumber;
                    row.Cells[colMap.HS_CODE].Value = item.hsCode;
                    row.Cells[colMap.HS_DESC].Value = item.hsDescription;
                    row.Cells[colMap.OWNER].Value = item.cargoOwner;
                    row.Cells[colMap.RATING].Value = item.rating;
                    row.Cells[colMap.STATUS].Value = item.status;
                    row.Cells[colMap.RISK].Value = showRisk ? item.riskScore.ToString() : "-" ;
                    row.Cells[colMap.UNSEAL].Value = showUnseal ? "Unseal Inspect" : "";
                    row.Cells[colMap.REPORT].Value = showReport ? "Report Exception" : "";
                    row.Cells[colMap.RELEASE].Value = showRelease ? "Release" : "";

                    row.Tag = item;
                    
                }
                

            }
        }
        private int getStatusOrder(string status)
        {
            if (status == StatusUtils.InitialInspection) return 0;
            if (status == StatusUtils.UnsealingInspection) return 1;
            if (status == "Exception") return 2;
            if (status == StatusUtils.Released) return 3;

            return 4;
        }
        public void echoParentVoyage(VoyageControl card, string number)
        {
            this.currentVoyage = number;
            lb_voyage_number_xxx.Text = "Voyage Number:" + number;

            if (selectedCard != null)
            {
                selectedCard.setSelectedCard(false);
            }

            selectedCard = card;
            selectedCard.setSelectedCard(true);


            // init container number option
            using (var db = new S2DBEntities())
            {
                var container = db.containers
                    .Where(x => x.voyage_number == number)
                    .Select(x => x.container_number)
                    .ToList();

                cb_container_number.Items.Add("All");
                cb_container_number.Items.AddRange(container.ToArray());
                cb_container_number.SelectedIndex = 0;
            }
            refreshGridData();
        }



        private string getFilterValue(Control control)
        {
            string text = control.Text.Trim();
            return "All".Equals(text) ? "" : text;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (currentVoyage.Length == 0)
            {
                MessageBox.Show("Please select a voyage first");
                return;
            }

            using (var db = new S2DBEntities())
            {
                bool started = db.security_check
                    .AsNoTracking()
                    .Any(s => s.container.voyage_number == currentVoyage);
                if (started)
                {
                    MessageBox.Show("The security check of this voyage has been started");
                    return;
                }

                if (!MsgUtils.Confirm("Are you sure to start the security check of this voyage?")) return;

                int? approvedId = db.declaration_status
                    .AsNoTracking()
                    .Where(s => s.status == StatusUtils.Approved)
                    .Select(s => (int?)s.id)
                    .FirstOrDefault();
                int? initialId = db.security_check_status
                    .AsNoTracking()
                    .Where(s => s.status == StatusUtils.InitialInspection)
                    .Select(s => (int?)s.id)
                    .FirstOrDefault();

                if (!approvedId.HasValue || !initialId.HasValue)
                {
                    MessageBox.Show("The security check configuration is incomplete");
                    return;
                }

                var containers = db.containers
                    .AsNoTracking()
                    .Where(c => c.voyage_number == currentVoyage
                        && c.declarations.Any(d => d.declaration_status_id == approvedId.Value))
                    .Select(c => c.container_number)
                    .ToList();
                if (containers.Count == 0)
                {
                    MessageBox.Show("No approved container was found on this voyage");
                    return;
                }

                DateTime now = DateTime.Now;
                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (string containerNumber in containers)
                    {
                        var check = new security_check
                        {
                            container_number = containerNumber,
                            check_time = now,
                            inspector = CurrentOfficer.JobNumber,
                            current_status = initialId.Value
                        };
                        check.sc_status_change.Add(new sc_status_change
                        {
                            sc_status_id = initialId.Value,
                            change_time = now
                        });
                        db.security_check.Add(check);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
            }

            MessageBox.Show("Security check started");
        }



        private void batchOperate(string targetStatus)
        {
            var checkedRows = getCheckedRows();

            if (checkedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one container");
                return;
            }

            bool hasInitial = checkedRows.Any(r => r.status == StatusUtils.InitialInspection);
            bool hasUnsealing = checkedRows.Any(r => r.status == StatusUtils.UnsealingInspection);
            if (hasInitial && hasUnsealing)
            {
                MessageBox.Show("Initial inspection and unsealing inspection containers can not be mixed");
                return;
            }

            if (targetStatus == StatusUtils.UnsealingInspection && !hasInitial)
            {
                MessageBox.Show("Batch unseal inspect is only for initial inspection containers");
                return;
            }

            if (targetStatus == StatusUtils.Released
                && hasInitial
                && checkedRows.Any(r => r.riskScore >= RiskCalculator.HighRiskScore))
            {
                MessageBox.Show("High risk containers can not be released in batch");
                return;
            }

            if (!MsgUtils.Confirm("Are you sure to batch update " + checkedRows.Count + " containers to " + targetStatus + "?")) return;

            var checkIds = checkedRows
                .Select(r => r.securityCheckId)
                .Where(id => id > 0)
                .Distinct()
                .ToList();
            if (checkIds.Count != checkedRows.Count)
            {
                MessageBox.Show("One or more selected containers have no security check record");
                return;
            }

            updateScStatuses(checkIds, targetStatus);
        }

        private List<SecurityRow> getCheckedRows()
        {
            var rows = new List<SecurityRow>();
            foreach (DataGridViewRow gridRow in datagridview.Rows)
            {
                bool isChecked = gridRow.Cells[colMap.CHECK].Value is bool
                    && (bool)gridRow.Cells[colMap.CHECK].Value;
                if (isChecked && gridRow.Tag is SecurityRow)
                {
                    rows.Add((SecurityRow)gridRow.Tag);
                }
            }
            return rows;
        }

        private void btn_batch_unseal_Click(object sender, EventArgs e)
        {
            batchOperate(StatusUtils.UnsealingInspection);
        }

        private void btn_batch_release_Click(object sender, EventArgs e)
        {
            batchOperate(StatusUtils.Released);
        }



        private void updateScStatuses(List<int> securityCheckIds, string statusName)
        {
            using (var db = new S2DBEntities())
            {
                int? targetId = db.security_check_status
                    .AsNoTracking()
                    .Where(s => s.status == statusName)
                    .Select(s => (int?)s.id)
                    .FirstOrDefault();
                var checks = db.security_check
                    .Where(s => securityCheckIds.Contains(s.id))
                    .ToList();
                if (!targetId.HasValue || checks.Count != securityCheckIds.Count)
                {
                    MessageBox.Show("The security check data has changed. Please refresh and try again");
                    return;
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var check in checks)
                    {
                        StatusUtils.setSecurity(db, check, targetId.Value);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
            }
        }
    }
}
