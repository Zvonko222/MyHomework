using System;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.ui;
using S2.util;
namespace S2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Password must be shown as cipher text
            tb_password.PasswordChar = '*';
            img.SizeMode = PictureBoxSizeMode.Zoom;

            // Fill the last successful login
            tb_job_number.Text = Properties.Settings.Default.LoginJobNumber;
            tb_password.Text = Properties.Settings.Default.LoginPassword;

            // Form shows in the center of the screen with the logo
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string jobNumber = tb_job_number.Text.Trim();
            string password = tb_password.Text.Trim();

            // Validation: job number and password are required
            if (FormatUtils.isEmpty(jobNumber)|| FormatUtils.isEmpty(password))
            {
                MessageBox.Show("Job number and password can not be empty");
                return;
            }

            try
            {
                using (var db = new S2DBEntities())
                {
                    var officer = db.customs_officer
                        .AsNoTracking()
                        .Where(x => x.job_number == jobNumber && x.password == password)
                        .FirstOrDefault();

                    if (officer == null)
                    {
                        MessageBox.Show("Job number or password is incorrect");
                        return;
                    }

                    string roleName = db.roles
                        .Where(x => x.id == officer.role_id)
                        .Select(x => x.name)
                        .FirstOrDefault();

                    // Save the login officer info
                    CurrentOfficer.JobNumber = officer.job_number;
                    CurrentOfficer.FirstName = officer.first_name;
                    CurrentOfficer.LastName = officer.last_name;
                    CurrentOfficer.RoleName = roleName;

                    // Remember the successful login for next time
                    Properties.Settings.Default.LoginJobNumber = jobNumber;
                    Properties.Settings.Default.LoginPassword = password;
                    Properties.Settings.Default.Save();

                    // Open the customs main page
                    new MainForm().Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message);
            }
        }
    }
}
