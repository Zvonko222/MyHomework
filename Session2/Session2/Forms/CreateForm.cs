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
    public partial class CreateForm : Form
    {
        private bool clickFlag = false;
        public CreateForm()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {


        }



        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string fullName = tb_fullname.Text;
            string pwd = tb_password.Text;
            string pwdAgain = tb_password_again.Text;
            string gender = "";
            string birthday = dateTimePicker1.Value.ToString();
            int numberOfFamliyMembers = Convert.ToInt32(nud_number_of_family_members.Value);


            // Verification
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(tb_username);
            textBoxes.Add(tb_fullname);
            textBoxes.Add(tb_password);
            foreach(TextBox textbox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textbox.Text.ToString()))
                {
                    MessageBox.Show($"{textbox.Name} cannot is a null");
                    textbox.Focus();
                    return;
                }
            }
            if (!clickFlag)
            {
                MessageBox.Show("Please onClick View Terms and Condition");
                return;
            }
            if(tb_password.TextLength < 5)
            {
                MessageBox.Show("Password is to short");
                return;
            }
            if (pwd != pwdAgain)
            {
                MessageBox.Show("passwords do not match");
                return;
            }
            if (cb_agree.Checked == false)
            {
                MessageBox.Show("Please agree to the Terms and Conditions");
                return;
            }

            if (rb_female.Checked)
            {
                gender = "female";
            }
            else if (rb_male.Checked)
            {
                gender = "male";
            }
            else
            {
                MessageBox.Show("Please select gender");
                return;
            }

            // Query
            string sql = $"" +
                $"select Username " +
                $"from Users " +
                $"where Username = '{username}'";



            DataTable table = DBHelper.executeQuery(sql);
            if (table.Rows.Count != 0)
            {
                MessageBox.Show("This username is exsit");
                return;
            }

            // Insert
            sql = $"" +
                $"insert into Users ([Username],[FullName],[Password],[BirthDate],[Gender],[FamilyCount],[UserTypeID]) " +
                $"values ('{username}','{fullName}','{pwd}','{birthday}','{gender}','{numberOfFamliyMembers}','1') ";
            bool result = DBHelper.executeNonQuery(sql);
            if (result)
            {
                MessageBox.Show("Register Successfully");
                WelcomeForm welcomeForm = new WelcomeForm();
                welcomeForm.Show();
                this.Hide();
                return;
            }
            else
            {
                MessageBox.Show("Register Failed");
                return;
            }
        }

        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickFlag = true;
        }
    }
}
