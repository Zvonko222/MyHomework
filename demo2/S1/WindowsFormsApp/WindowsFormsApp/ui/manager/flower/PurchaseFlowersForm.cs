using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.data.model.db;
using WindowsFormsApp.data.model.dto;
using WindowsFormsApp.ui.manager.flower;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp.ui.manager
{
    public partial class PurchaseFlowersForm : Form
    {
        private string staffId;
        private List<FlowerDto> data;
        private List<FlowerDto> currentData;
        public PurchaseFlowersForm(string staffId)
        {
            this.staffId = staffId;
            InitializeComponent();
            this.FormClosed += PurchaseFlowersForm_FormClosed;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }
        // Change combobox index
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedName))
            {
                return;
            }
            // ALL
            if (selectedName.Equals("ALL"))
            {
                initFlow();
                currentData = data;
                return;
            }
            // Another
            var result = data
                .Where(x => x.flowerName.Equals(selectedName))
                .ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach(var flower in result)
            {
                MessageItem item = new MessageItem(
                    null,
                    flower.flowerName,
                    flower.category,
                    flower.price
                    );

                flowLayoutPanel1.Controls.Add(item);   
            }
            currentData = result;
            return;
        }



        // Form Close
        private void PurchaseFlowersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PurchaseFlowersForm_Load(object sender, EventArgs e)
        {
            initData();
            initFlow();
            initComboBox();

        }
        // Create usercontrol all data in flowlayoutpanel
        private void initFlow()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var flower in data)
            {
                MessageItem item = new MessageItem(
                    null,
                    flower.flowerName.ToString(),
                    flower.category.ToString(),
                    (double)flower.price
                    );
                flowLayoutPanel1.Controls.Add(item);
            }
        }
        // Query data
        private void initData()
        {
            using (var db = new Session1Entities())
            {
                data = db.Flowers
                    .AsEnumerable()
                    .Select(x => new FlowerDto
                    {
                        flowerName = x.FlowerName,
                        category = x.FlowerCategory.CategoryName,
                        price = Convert.ToDouble(x.UnitPrice),
                        image = null
                    })
                    .ToList();

                if (data.Count == 0)
                {
                    MessageBox.Show("Database not found");
                    return;
                }
            }
        }

        private void initComboBox()
        {
            List<object> nameList = new List<object>();
            comboBox1.DataSource = null;
            nameList.Add("ALL");
            foreach(var flower in data)
            {
                nameList.Add(flower.flowerName);
            }
            comboBox1.DataSource = nameList;
            comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string flowerName = textBox1.Text;

            var result = currentData
                .Where(x => x.flowerName.Contains(flowerName))
                .ToList();

            flowLayoutPanel1.Controls.Clear();
            foreach (var flower in result)
            {
                MessageItem item = new MessageItem(
                    null,
                    flower.flowerName,
                    flower.category,
                    flower.price
                    );
                flowLayoutPanel1.Controls.Add(item);
            }
        }
    }
}
