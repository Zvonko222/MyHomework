using Session2.Forms;
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

namespace Session2
{
    public partial class WelcomeForm : System.Windows.Forms.Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string employee = tb_employee.Text;
            string user = tb_user.Text;
            string pwd = tb_password.Text;

            string sql = $"" +
                $"select Username,Password " +
                $"from Users " +
                $"where Username = '{user}' ";
            DataTable table = DBHelper.executeQuery(sql);
            if(table.Rows.Count == 0)
            {
                //ERROR
                MessageBox.Show("ERROR");
                return;
            }
            if (table.Rows[0]["Password"].ToString() == pwd)
            {
                MessageBox.Show("Login Successfully");

            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateForm createForm = new CreateForm();
            createForm.FormClosed += FrmClosed;
            createForm.Show();
            this.Hide();
        }

        private void FrmClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
