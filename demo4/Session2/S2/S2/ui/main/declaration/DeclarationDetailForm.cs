using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.data.models;
using S2.ui.main.declaration;
using S2.util;

namespace S2.ui
{
    public partial class DeclarationDetailForm : Form
    {
        private readonly DeclarationRow item;


        public DeclarationDetailForm(DeclarationRow item)
        {
            this.item = item;
            InitializeComponent();

            initControl();
            loadData();
        }

        private void initControl()
        {
            UiUtils.setCenter(this);
            initAutoButton();
        }

        private void initAutoButton()
        {
            bool isShowAuto = getContainerCount() >= 2;
            btnAutoDuty.Visible = isShowAuto;
        }

        private void loadData()
        {
            lblVoyageNumber.Text = "Voyage Number: " + item.voyageNumber;
            lblContainerNumber.Text = "Container Number: " + item.containerNumber;
            lblCountry.Text = "Country of Origin: " + item.originCountry;
            lblTradeMode.Text = "Trade Mode: " + item.tradeMode;
            lblCargoAmount.Text = "Cargo Amount: " + item.cargoAmount.ToString("0.00");
            lblDutyPayable.Text = "Duty Payable: " + item.dutyPayable.ToString("0.00");
            lblHsCode.Text = "HS Code: " + item.hsCode;
            tbDesc.Text = item.description;
        }

        private void btnAutoDuty_Click(object sender, EventArgs e)
        {
            openDutyCalculate();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are yoe sure to approve this declaration", "Confirm", MessageBoxButtons.YesNo)
                          == DialogResult.No)
            {
                return;
            }

            using (var db = new S2DBEntities())
            {
                var _item = db.declarations.First(d => d.id == this.item.declarationId);
                StatusUtils.setDeclaration(db, _item, StatusUtils.Approved, "Approved");
                db.SaveChanges();
            }
            MessageBox.Show("The declaration has been approved");
            Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            var form = new RejectForm();
            if (form.ShowDialog() != DialogResult.OK || form.reason.Length == 0) return;
            string reason = form.reason;

            using (var db = new S2DBEntities())
            {
                var item = db.declarations.First(d => d.id == this.item.declarationId);
                StatusUtils.setDeclaration(db, item, StatusUtils.Rejected, reason);
                db.SaveChanges();
            }
            MessageBox.Show("The declaration has been rejected");
            Close();
        }

        private int getContainerCount()
        {
            using (var db = new S2DBEntities())
            {
                return db.declarations
                    .AsNoTracking()
                    .Count(d => d.container_number == item.containerNumber);
            }
        }

        private void openDutyCalculate()
        {
            var form = new DutyCalculateForm(item.declarationId);
            form.ShowDialog(this);

            using (var db = new S2DBEntities())
            {
                string status = db.declarations
                    .AsNoTracking()
                    .Where(d => d.id == item.declarationId)
                    .Select(d => d.declaration_status.status)
                    .First();
                if (status != StatusUtils.Pending) Close();
            }
        }

       
     
    }
}
