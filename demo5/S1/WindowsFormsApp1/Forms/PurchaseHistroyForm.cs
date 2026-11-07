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
    public partial class PurchaseHistroyForm : Form
    {
        public string id;
        public PurchaseHistroyForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PurchaseHistroyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PurchaseHistroyForm_Load(object sender, EventArgs e)
        {
            using(var db = new Session1Entities())
            {
                var data = db.PurchaseOrderDetails
                    .Select(p => new
                    {
                        OrderNumber = p.PurchaseOrder.OrderNo,
                        OrderDate = p.PurchaseOrder.OrderDate,
                        Delivery = p.PurchaseOrder.DeliveryDate,
                        Status = p.PurchaseOrder.Status,
                        Store = p.PurchaseOrder.Store.StoreName,
                        Total = p.LineTotal
                    })
                    .ToList();
                dataGridView1.Refresh();
                dataGridView1.DataSource = data;
            }
            cb_status.SelectedIndex = 0;
            cb_serach_by.SelectedIndex = 0;
            dataGridView1.ReadOnly = true;
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Action";
            //btn.Text = "View Detail";
            //dataGridView1.Columns.Add(btn);


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string orderBy = cb_serach_by.Text;
            if(orderBy == "OrderDate")
            {
                using (var db = new Session1Entities())
                {
                    var data = db.PurchaseOrderDetails
                        .OrderBy(p => p.PurchaseOrder.OrderDate)
                        .Select(p => new
                        {
                            OrderNumber = p.PurchaseOrder.OrderNo,
                            OrderDate = p.PurchaseOrder.OrderDate,
                            Delivery = p.PurchaseOrder.DeliveryDate,
                            Status = p.PurchaseOrder.Status,
                            Store = p.PurchaseOrder.Store.StoreName,
                            Total = p.LineTotal
                        })
                        .ToList();
                    dataGridView1.Refresh();

                    dataGridView1.DataSource = data;
                }
                //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                //btn.HeaderText = "Action";
                //btn.Text = "View Detail";
                //dataGridView1.Columns.Add(btn);
            }
            if(orderBy == "DeliveryDate")
            {
                using (var db = new Session1Entities())
                {
                    var data = db.PurchaseOrderDetails
                        .OrderBy(p => p.PurchaseOrder.DeliveryDate)
                        .Select(p => new
                        {
                            OrderNumber = p.PurchaseOrder.OrderNo,
                            OrderDate = p.PurchaseOrder.OrderDate,
                            Delivery = p.PurchaseOrder.DeliveryDate,
                            Status = p.PurchaseOrder.Status,
                            Store = p.PurchaseOrder.Store.StoreName,
                            Total = p.LineTotal
                        })
                        .ToList();
                    dataGridView1.Refresh();

                    dataGridView1.DataSource = data;
                }
                //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                //btn.HeaderText = "Action";
                //btn.Text = "View Detail";
                //dataGridView1.Columns.Add(btn);
            }
        }
    }
}
