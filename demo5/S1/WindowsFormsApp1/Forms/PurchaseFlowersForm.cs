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
    public partial class PurchaseFlowersForm : Form
    {
        public string id;
        public PurchaseFlowersForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        public PurchaseFlowersForm()
        {
            InitializeComponent();

        }

        private void PurchaseFlowersForm_Load(object sender, EventArgs e)
        {
            using (var db = new Session1Entities())
            {
                var data = db.Flowers
                    .Select(f => new
                    {
                        FlowerName = f.FlowerName,
                        Price = f.UnitPrice,
                        Description = f.Description,
                        imgId = f.CoverImage,
                        Categroy = f.FlowerCategory.CategoryID
                    })
                    .ToList();
                dataGridView1.DataSource = data;

                var item = data
                    .Select(i => i.FlowerName)
                    .ToList();
                cb_serach.SelectedIndex = 0;
            }
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            dataGridView1.ReadOnly = true;

        }



        private void tb_flower_name_TextChanged(object sender, EventArgs e)
        {
            using (var db = new Session1Entities())
            {
                var data = db.Flowers
                    .Where(f => f.FlowerName.Contains(tb_flower_name.Text))
                    .Select(f => new
                    {
                        FlowerName = f.FlowerName,
                        Price = f.UnitPrice,
                        Description = f.Description,
                        imgId = f.CoverImage,
                        Categroy = f.FlowerCategory.CategoryID
                    })
                    .ToList();
               
                dataGridView1.DataSource = data;
                
            }
        }

        private void PurchaseFlowersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells["FlowerName"].Tag == null)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells["FlowerName"].Tag = 0;
            //}
            
            //dataGridView1.Rows[e.RowIndex].Tag = tag
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
