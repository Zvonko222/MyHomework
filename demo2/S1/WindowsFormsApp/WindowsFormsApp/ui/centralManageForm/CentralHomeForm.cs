using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.ui.centralManageForm
{
    public partial class CentralHomeForm : Form
    {
        private string staffId;
        public CentralHomeForm(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        // On click Purchase form button
        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseOrderForm form = new PurchaseOrderForm(staffId);
            form.Show();
            this.Hide();
        }
        // On click flower form button
        private void button2_Click(object sender, EventArgs e)
        {
            FlowerForm form = new FlowerForm(staffId);
            form.Show();
            this.Hide();
        }
        // On click materials form button
        private void button3_Click(object sender, EventArgs e)
        {
            MaterialsForm form = new MaterialsForm(staffId);
            form.Show();
            this.Hide();
        }
    }
}
