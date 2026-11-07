using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.data.models;
using S2.util;

namespace S2.ui
{
    /// <summary>Report a security check exception for one container.</summary>
    public partial class ReportExceptionForm : Form
    {
        private readonly int securityCheckId;
        private SecurityRow row;
        private string currentVoyage;

        public ReportExceptionForm()
        {
        }

        public ReportExceptionForm(SecurityRow row, string currentVoyage) 
        {
            InitializeComponent();

            this.currentVoyage = currentVoyage;
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            initControl(currentVoyage, row.containerNumber, row.cargoOwner);
            loadData();
            this.row = row;
        }

        private void initControl(string voyageNumber, string containerNumber, string cargoOwner)
        {
            lb_voyage_number_xxx.Text = "Voyage Number: " + voyageNumber;
            lb_container_number_xxx.Text = "Container Number: " + containerNumber;
            lb_cargo_onwer_xxx.Text = "Cargo Owner: " + cargoOwner;

            UiUtils.setCenter(this);
        }

        private void loadData()
        {
            using (var db = new S2DBEntities())
            {
                var data = db.exception_type
                    .AsNoTracking()
                    .OrderBy(t => t.id)
                    .Select(t => new OptionItem
                    {
                        Id = t.id,
                        Name = t.type
                    })
                    .ToList();

                foreach (var type in data)
                {
                    cb_exception_type.Items.Add(type);
                }
            }
            cb_exception_type.DisplayMember = "Name";
            cb_exception_type.ValueMember = "Id";
            if (cb_exception_type.Items.Count > 0) cb_exception_type.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void submit()
        {
            var type = cb_exception_type.SelectedItem as OptionItem;
            string detail = tbDetail.Text.Trim();
            if (type == null)
            {
                MessageBox.Show("Please select an exception type");
                return;
            }
            if (detail.Length == 0)
            {
                MessageBox.Show("Please input the exception detail");
                return;
            }
            if (!MsgUtils.Confirm("Are you sure to submit the exception?")) return;

            using (var db = new S2DBEntities())
            {
                var check = db.security_check.FirstOrDefault(s => s.id == securityCheckId);
                if (check == null)
                {
                    MessageBox.Show("The security check record could not be found");
                    return;
                }

                DateTime now = DateTime.Now;
                using (var transaction = db.Database.BeginTransaction())
                {
                    db.security_check_exception.Add(new security_check_exception
                    {
                        security_check_id = securityCheckId,
                        exception_type_id = type.Id,
                        detail = detail,
                        inspector = CurrentOfficer.JobNumber,
                        submit_time = now
                    });
                    StatusUtils.setSecurity(db, check, StatusUtils.Exception);
                    db.SaveChanges();
                    transaction.Commit();
                }
            }

            MessageBox.Show("The exception has been submitted");
            Close();
        }

        private sealed class OptionItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
