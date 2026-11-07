using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Forms
{
    public partial class PurchaseOder : Form
    {
        public PurchaseOder()
        {
            InitializeComponent();
        }

        private void PurchaseOder_Load(object sender, EventArgs e)
        {
            using(var db = new Session1Entities())
            {
                var data = db.PurchaseOrderDetails
                    .Select(p => new
                    {
                        OrderNum = p.PurchaseOrder.OrderNo,
                        OrderDate = p.PurchaseOrder.OrderDate,
                        Store = p.PurchaseOrder.Store,
                        total = p.PurchaseOrder.TotalAmount,
                        status = p.PurchaseOrder.Status,
                        details = "view",
                       action = "action"
                    })
                    .ToList();
                dataGridView1.DataSource = data;
            }
        }
    }
}
