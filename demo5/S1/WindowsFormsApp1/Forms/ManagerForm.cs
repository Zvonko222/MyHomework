using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class ManagerForm : Form
    {
        public  string id;
        public ManagerForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_purchase_flowers_Click(object sender, EventArgs e)
        {
            PurchaseFlowersForm form = new PurchaseFlowersForm(id);
            form.Show();
            this.Hide();
        }

        private void btn_purchase_histroy_Click(object sender, EventArgs e)
        {
            PurchaseHistroyForm form = new PurchaseHistroyForm(id);
            form.Show();
            this.Hide();
        }
    }
}
