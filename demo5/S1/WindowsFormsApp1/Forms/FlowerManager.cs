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
    public partial class FlowerManager : Form
    {
        public FlowerManager()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void FlowerManager_Load(object sender, EventArgs e)
        {
            using (var db = new Session1Entities())
            {
                var data = db.Flowers
                    .Select(f => new
                    {
                        FlowerName = f.FlowerName,
                        UnitPrice = f.UnitPrice,
                        Categroy = f.FlowerCategory.CategoryID,
                        Action = "edit"

                    })
                    .ToList();

                dataGridView1.DataSource = data;


            }

            dataGridView1.ReadOnly = true;
        }
    }
}
