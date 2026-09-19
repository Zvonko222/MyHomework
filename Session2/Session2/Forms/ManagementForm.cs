using Session2.Models;
using Session2.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2.Forms
{
    public partial class ManagementForm : Form
    {
        DataTable table;
        public ManagementForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();
        }

        private void ManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {
            using(var db = new Session2Entities())
            {
                var data = db.Items
                    .Select(i => new
                    {
                        Title = i.Title,
                        Capacity = i.Capacity,
                        Area = i.Area.Name,
                        Type = i.ItemType.Name
                    })
                    .ToList();
                dataGridView1.DataSource = data;
                dataGridView2.DataSource = data;
                l_item_found.Text = data.Count + " items found.";
            }


            

            if (!dataGridView2.Columns.Contains("btnEdit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();

                editColumn.Name = "btnEdit";
                editColumn.HeaderText = "Edit";
                editColumn.Text = "Edit Details";
                editColumn.UseColumnTextForButtonValue = true;

                dataGridView2.Columns.Add(editColumn);
            }
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;


            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                AddListDataModel list = new AddListDataModel();
                list.title = dataGridView2.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                list.capacity = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["Capacity"].Value);
                list.area = dataGridView2.Rows[e.RowIndex].Cells["Area"].Value.ToString();
                list.type = dataGridView2.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                AddEditForm addEditForm = new AddEditForm(list);
                addEditForm.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm("AddForm");
            addEditForm.Show();
            this.Hide();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            string text = tb_search.Text;
            DataView view = table.DefaultView;
            view.RowFilter = $"Title like '%{text}%'";
            dataGridView1.DataSource = view;
        }
    }
}
