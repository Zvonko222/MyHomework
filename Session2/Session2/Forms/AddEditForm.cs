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
    public partial class AddEditForm : Form
    {
        AddListDataModel addListDataModel = new AddListDataModel();
        private string v;

        public AddEditForm(AddListDataModel list)
        {
            InitializeComponent();
            this.addListDataModel = list;
            
            this.Text = "Seoul Stay - Edit Listing "+ list.title;
            tb_title.Text = addListDataModel.title;
            //....

        }

        public AddEditForm()
        {
            InitializeComponent();
        }

        public AddEditForm(string v)
        {
            InitializeComponent();

            this.v = v;
            MessageBox.Show(v);
            if (v == "AddForm")
            {
                this.Text = "Seoul Stay - Add Listing";
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Tv");
            dataGridView1.Rows.Add("Music Player");
            dataGridView1.Rows.Add("BBQ Grill");
            dataGridView1.Rows.Add("Smoke alarm");
            dataGridView1.Rows.Add("WIFI");

            string sql = $"" +
                $"select " +
                $"atr.Name as Attraction, " +
                $"a.Name as Area, " +
                $"ia.Distance, " +
                $"ia.DurationOnFoot as OnFoot, " +
                $"ia.DurationByCar as ByCar " +
                $"from ItemAttractions ia " +
                $"join Attractions atr " +
                $"on atr.ID = ia.AttractionID " +
                $"join Areas a " +
                $"on a.ID = atr.AreaID " +
                $"";
                // attraction Area Distance OnFoot ByCar
            DataTable table = DBHelper.executeQuery(sql);
            dataGridView2.DataSource = table;

            DataTable t = new DataTable();
            t.Columns.Add("AAA");
            t.Columns.Add("BBB");
            t.Rows.Add(1, "Hotel");
            t.Rows.Add(2, "Apartment");

            cb_type.DataSource = t;
            cb_type.DisplayMember = "BBB";

        }

        private void AddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_close_finish_Click(object sender, EventArgs e)
        {
            //save and close
            //....

        }
    }
}
