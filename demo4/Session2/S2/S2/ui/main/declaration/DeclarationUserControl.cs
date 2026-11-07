using System;
using System.Drawing;
using System.Windows.Forms;
using S2.data.models;
using S2.util;

namespace S2.ui.main.control
{
    public partial class DeclarationUserControl : UserControl
    {
        private readonly string status;
         private DeclarationRow item;

 
        public DeclarationUserControl(DeclarationRow item)
        {
            InitializeComponent();
            this.item = item;
            status = item.status;
            loadControl(item);
        }

        private void loadControl(DeclarationRow item)
        {
            label1.Text = "Container Number: " + item.containerNumber;
            label2.Text = "Country of Origin: " + item.originCountry;
            label3.Text = "Duty Payable: " + item.dutyPayable.ToString("0.00");
            label4.Text = "Cargo Owner: " + item.cargoOwner;
            label5.Text = "Trade Mode: " + item.tradeMode;
            label7.Text = "HS Code: " + item.hsCode;
            label8.Text = "Cargo Amount: " + item.cargoAmount.ToString("0.00");
            label9.Text = "Declaration Id: " + item.declarationId;

            label6.Text = "Declared Time" + item.declarationTime.ToString("yyyy-MM-dd");

            btn_status.Text = item.status;
            if (item.status == StatusUtils.Approved)
            {
                btn_status.BackColor = Color.Green;
            }
            else
            {
                btn_status.BackColor = item.status == StatusUtils.Rejected ? Color.Red : Color.Blue;
            }

            if (item.status == StatusUtils.Rejected)
            {
                btn_view_reason.Text = "View Reason";
            }
            else
            {
                btn_view_reason.Text = "View Detail";
            }
        }

        private void btn_view_reason_Click(object sender, EventArgs e)
        {
            if (status == StatusUtils.Pending)
            {
                DeclarationDetailForm form = new DeclarationDetailForm(item);
                form.Show();
            }
            else if (status == StatusUtils.Rejected)
            {
                MessageBox.Show(item.rejectReason);
            }
            else 
            {
                MessageBox.Show("Does not realized");
            }
        }
    }
}
