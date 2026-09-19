using Session2.Forms;
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
            string username = tb_user.Text;
            string pwd = tb_password.Text;

            if (string.IsNullOrWhiteSpace(tb_employee.Text))
            {
                using(var db = new Session2Entities())
                {
                    var dbPwd = db.Users
                        .Where(u => u.Username == username)
                        .Select(u => u.Password)
                        .FirstOrDefault();
                    if(dbPwd == null || dbPwd != pwd)
                    {
                        MessageBox.Show("ERROR");
                        return;
                    }
                    if(dbPwd == pwd)
                    {
                        MessageBox.Show("Login Successfully");
                        ManagementForm managementForm = new ManagementForm();
                        managementForm.Show();
                        this.Hide();
                        return;
                    }
                    
                }
            }
            else
            {
                using (var db = new Session2Entities())
                {
                    var data = db.Users
                        .Where(u => u.FullName == employee)
                        .Select(u => u.Password)
                        .FirstOrDefault();
                    if (data == null)
                    {
                        MessageBox.Show("");
                        return;
                    }
                    MessageBox.Show("Login Successfully");
                    ManagementForm managementForm = new ManagementForm();
                    managementForm.Show();
                    this.Hide();
                    return;
                }
            }

            // Login Again Verification
            if (cb_keep_sign.Checked)
            {
                Properties.Settings.Default.password = tb_password.Text;
                Properties.Settings.Default.username = tb_user.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
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

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            tb_password.UseSystemPasswordChar = true;
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.username))
            {
                tb_user.Text = Properties.Settings.Default.username;
                tb_password.Text = Properties.Settings.Default.password;
                cb_keep_sign.Checked = true;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            tb_password.UseSystemPasswordChar = !cb_show_password.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
