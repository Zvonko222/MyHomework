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
using WindowsFormsApp.data.model.dto;
using WindowsFormsApp.ui.manager.history;

namespace WindowsFormsApp.ui.centralManageForm
{
    public partial class PurchaseOrderForm : Form
    {
        public PurchaseOrderForm(string staffId)
        {
            InitializeComponent();
            this.Load += PurchaseOrderForm_Load;
            this.FormClosed += PurchaseOrderForm_FormClosed;
        }
        private List<HistoryDto> data;
        private List<HistoryDto> currentData;
        private void PurchaseOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void PurchaseOrderForm_Load(object sender, EventArgs e)
        {
            initControls();
            initData();
        }

        private void initData()
        {
            using(var db = new Session1Entities())
            {
                var data = db.PurchaseOrders
                    .AsEnumerable()
                    .Select(x => new HistoryDto
                    {
                        orderNo = x.OrderNo,
                        orderDate = x.OrderDate,
                        storeName = x.Store.StoreName,
                        totalAmount = Convert.ToDouble(x.TotalAmount),
                        status = x.Status,
                        detail = "View",
                        action = null
                    })
                    .ToList();
                if(data.Count == 0)
                {
                    MessageBox.Show("ERROR,Data does not found");
                    return;
                }
                  
            }
        }

        private void initControls()
        {
            initDateTimePicker();
            initStatus();
        }

        private void initStatus()
        {
            List<string> list = new List<string>();
            list.Add(StatusEnum.All.ToString());
            list.Add(StatusEnum.Prepare.ToString());
            list.Add(StatusEnum.Pending_Delivery.ToString());
            list.Add(StatusEnum.Completed.ToString());

            comboBox1.DataSource = list;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        private void initDateTimePicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
    }
}
