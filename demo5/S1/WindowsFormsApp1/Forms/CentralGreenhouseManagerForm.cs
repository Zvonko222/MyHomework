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
    public partial class CentralGreenhouseManagerForm : Form
    {
        public CentralGreenhouseManagerForm(string staffId)
        {
            InitializeComponent();
        }

        private void btn_purchase_flowers_Click(object sender, EventArgs e)
        {
            PurchaseOder form = new PurchaseOder();
            form.Show();
            this.Hide();
        }

        private void btn_purchase_histroy_Click(object sender, EventArgs e)
        {
            FlowerManager form = new FlowerManager();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MaterialManagement form = new MaterialManagement();
            form.Show();
            this.Hide();
        }
    }
}
