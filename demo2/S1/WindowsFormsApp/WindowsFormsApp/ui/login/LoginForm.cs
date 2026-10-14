using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.data.model.db;
using WindowsFormsApp.ui.centralManageForm;
using WindowsFormsApp.ui.manager;
using WindowsFormsApp.ui.manager.flower;

namespace WindowsFormsApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            this.FormClosed += LoginForm_FormClosed;
        }
        // Closed
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            checkLogin();
        }
        // Check Login Token
        private void checkLogin()
        {
            if (Properties.Settings.Default.staffId == "" &&
                Properties.Settings.Default.password == "")
            {
                return;
            }

            tb_staff_id.Text = Properties.Settings.Default.staffId;
            tb_password.Text = Properties.Settings.Default.password;

        }

        // On click login button
        private void button1_Click(object sender, EventArgs e)
        {
            string staffId = tb_staff_id.Text;
            string password = tb_password.Text;

            using (var db = new Session1Entities())
            {
                var roleName = db.Staffs
                    .Where(x => x.StaffID == staffId && x.Password == password)
                    .Select(x => x.StaffRole.RoleName)
                    .FirstOrDefault();
                if (roleName == null)
                {
                    MessageBox.Show("Account or password ERROR");
                    tb_password.Text = "";
                    return;
                }

                // Identity is Store Manager
                if (roleName.Equals("Store Manager"))
                {
                    memoryAccount(staffId, password);
                    ManageHomeForm form = new ManageHomeForm(staffId);
                    form.Show();
                    this.Hide();
                }
                // Identity is Central Greenhouse Manager
                if (roleName.Equals("Central Greenhouse Manager"))
                {
                    memoryAccount(staffId, password);
                    CentralHomeForm form = new CentralHomeForm(staffId);
                    form.Show();
                    this.Hide();
                }

            }
        }

        // Memory user account such as staffId,password
        private void memoryAccount(string staffId, string password)
        {
            Properties.Settings.Default.staffId = staffId;
            Properties.Settings.Default.password = password;
            Properties.Settings.Default.Save();
        }

        // On click cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
