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
            Nullable < System.DateTime > birthday = dateTimePicker1.Value;
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
            using (var db = new Session2Entities())
            {
                var dbUsername = db.Users
                    .Where(u => u.Username == username)
                    .Select(u => u.Username)
                    .FirstOrDefault();
                if(dbUsername != null)
                {
                    MessageBox.Show("This username is exist");
                    return;
                }
            }

            // Insert
            using (var db = new Session2Entities())
            {
                User user = new User();
                user.Username = username;
                user.FullName = fullName;
                user.Password = pwd;
                user.BirthDate = birthday;
                user.Gender = gender;
                user.FamilyCount = numberOfFamliyMembers;
                user.UserTypeID = 1;

                var data = db.Users
                    .Add(user);
                int result = db.SaveChanges();
                if(result <= 0)
                {
                    MessageBox.Show("Register Failed");
                    return;
                }
                else
                {
                    MessageBox.Show("Register Successfully");
                    WelcomeForm welcomeForm = new WelcomeForm();
                    welcomeForm.Show();
                    this.Hide();
                    return;
                }
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
