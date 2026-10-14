using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.ui.centralManageForm;
using WindowsFormsApp.ui.manager.history;

namespace WindowsFormsApp.ui.manager
{
    public partial class ManageHomeForm : Form
    {
        private string staffId;
        public ManageHomeForm(string staffId)
        {
            this.staffId = staffId;
            InitializeComponent();
        }
        // On click flowers button
        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseFlowersForm form = new PurchaseFlowersForm(staffId);
            form.Show();
            this.Hide();
        }
        // On click histroy button
        private void button2_Click(object sender, EventArgs e)
        {
            HistoryForm form = new HistoryForm(staffId);
            form.Show();
            this.Hide();
        }
    }
}
