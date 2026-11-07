using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string staffId = tb_staff_id.Text;
            string password = tb_password.Text;
            using (var db = new Session1Entities())
            {
                var data = db.Staffs
                    .Where(s => s.StaffID == staffId)
                    .Select(s => new
                    {
                        password = s.Password,
                        identity = s.StaffRole.RoleName
                    })
                    .FirstOrDefault();
                if(data == null)
                {
                    // 不存在该id的数据
                    MessageBox.Show("不存在该账号");
                    return;
                }
                if (isLogin(data.password, password))
                {
                    MessageBox.Show("登入成功");
                    ;
                    if (data.identity == "Store Manager")
                    {
                        ManagerForm form = new ManagerForm(staffId);
                        form.Show();
                        this.Hide();
                    }
                    if (data.identity == "Central Greenhouse Manager")
                    {
                        CentralGreenhouseManagerForm form = new CentralGreenhouseManagerForm(staffId);
                        form.Show();
                        this.Hide();
                    }
                   
                }
            }
        }

     

        public bool isLogin(string dbPassword, string password)
        {
            if(dbPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
