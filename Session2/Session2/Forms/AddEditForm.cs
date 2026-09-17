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
            btn_close_finish.Text = "Close";

            btn_next.Visible = false;

            //....

        }

        public AddEditForm()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                btn_next.Visible = true;
                btn_close_finish.Text = "Cancel";
            }else if(tabControl1.SelectedIndex == 1)
            {
                btn_close_finish.Text = "Cancel";
                btn_next.Visible = true;
            }else if(tabControl1.SelectedIndex == 2)
            {
                btn_next.Visible = false;
                btn_close_finish.Text = "Finish";
            }
        }

        public AddEditForm(string v)
        {
            InitializeComponent();

            this.v = v;
            //MessageBox.Show(v);
            if (v == "AddForm")
            {
                this.Text = "Seoul Stay - Add Listing";
                btn_close_finish.Text = "Cancel";
            }
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

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


            ManagementForm managementForm = new ManagementForm();
            managementForm.Show();
            this.Hide();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            // load
            ListingDetails listingDetails = new ListingDetails();
            listingDetails.type = cb_type.Text;
            listingDetails.title = tb_title.Text;
            listingDetails.capacity = Convert.ToInt32(nud_capacity.Value);
            listingDetails.numberOfBathrooms = Convert.ToInt32(nud_number_of_bathrooms);
            listingDetails.numberOfBeds = Convert.ToInt32(nud_number_of_beds);
            listingDetails.numberOfBedrooms = Convert.ToInt32(nud_number_of_bedrooms);
            listingDetails.approximateAddress = tb_approxinmate_address.Text;
            listingDetails.exactAdress = tb_exact_address.Text;
            listingDetails.desciption = tb_desciption.Text;
            listingDetails.hostRules = tb_host_rules.Text;
            listingDetails.minimum = Convert.ToInt32(nud_minimum.Value);
            listingDetails.maximum = Convert.ToInt32(nud_maximum.Value);

            // Verification data is null
            if (string.IsNullOrWhiteSpace(listingDetails.type))
            {
                MessageBox.Show("Type doesnt null");
                return;
            }
            if (string.IsNullOrWhiteSpace(listingDetails.title))
            {
                MessageBox.Show("Title doesnt null");
                return;
            }
            if (string.IsNullOrWhiteSpace(listingDetails.approximateAddress)){
                MessageBox.Show("Appoximate Address doesnt is null");
                return;
            }
            if (string.IsNullOrWhiteSpace(listingDetails.exactAdress))
            {
                MessageBox.Show("Exact Address doesnt is null");
                return;
            }
            if (string.IsNullOrWhiteSpace(listingDetails.desciption))
            {
                MessageBox.Show("Desciption doesnt is null");
                return;
            }
            if (string.IsNullOrWhiteSpace(listingDetails.hostRules))
            {
                MessageBox.Show("Host Rules doesnt is null");
                return;
            }

            // next
            if(tabControl1.SelectedIndex == 0)
            {
                tabControl1.SelectedIndex = 1;
            }else if(tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 2;
                btn_next.Visible = false;
            }

        }
    }
}
