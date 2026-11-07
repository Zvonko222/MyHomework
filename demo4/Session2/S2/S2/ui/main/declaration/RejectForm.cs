using System;
using System.Drawing;
using System.Windows.Forms;
using S2.util;

namespace S2.ui.main.declaration
{
    public partial class RejectForm : Form
    {
        private readonly TextBox tbReason = new TextBox();
        private readonly Button btnReject = new Button();
        private readonly Button btnCancel = new Button();

        public  string reason { get;private  set; }

        public RejectForm()
        {
            InitializeComponent();
            initControl();
            initListener();
        }

        private void initControl()
        {
            Text = "Reject Declaration";
            ClientSize = new Size(420, 220);
            UiUtils.setCenter(this);

            Label label = new Label
            {
                Text = "Rejection Reason:",
                Bounds = new Rectangle(30, 25, 120, 22)
            };
            tbReason.Multiline = true;
            tbReason.ScrollBars = ScrollBars.Vertical;
            tbReason.Bounds = new Rectangle(30, 52, 360, 100);

            btnReject.Text = "Reject";
            btnReject.Bounds = new Rectangle(210, 170, 85, 32);
            btnCancel.Text = "Cancel";
            btnCancel.Bounds = new Rectangle(305, 170, 85, 32);

            Controls.AddRange(new Control[] { label, tbReason, btnReject, btnCancel });
            AcceptButton = btnReject;
            CancelButton = btnCancel;
        }

        private void initListener()
        {
            btnReject.Click += BtnReject_Click; 
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void submit()
        {
            string reason = FormatUtils.getText(tbReason);
            if (reason.Length == 0)
            {
                MessageBox.Show("Please enter a rejection reason");
                return;
            }

            this.reason = reason;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
