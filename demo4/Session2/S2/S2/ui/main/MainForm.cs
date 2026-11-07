using System;
using System.ComponentModel;
using System.Windows.Forms;
using S2.util;

namespace S2.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            initControl();
            initListener();

        }

        private void initControl()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Text = CurrentOfficer.Title("Main Page");

            if (CurrentOfficer.RoleName != "Customs Manager")
            {
                tabPage3.Parent = null;
            }
        }

        private void initListener()
        {
            tabControl.SelectedIndexChanged += (s, e) => onSelectedChange();
        }

        private void onSelectedChange()
        {
            if (tabControl.SelectedTab == tabPage1)
            {
                tc_declaration.loadData();
                return;
            }

            if (tabControl.SelectedTab == tabPage2)
            {
                tc_security_check.loadData();
                return;
            }
            if (tabControl.SelectedTab == tabPage3)
            {
                tc_exception.loadData();
                return;
            }

        }


        private void declarationControl1_Load(object sender, EventArgs e) { }

        private void securityCheckControl1_Load(object sender, EventArgs e) { }
    }
}
