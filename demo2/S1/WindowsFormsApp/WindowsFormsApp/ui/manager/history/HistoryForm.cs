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

namespace WindowsFormsApp.ui.manager.history
{
    public partial class HistoryForm : Form
    {
        private StatusEnum status;
        private SearchByEnum searchBy;
        private DateTime dateStart;
        private DateTime dateEnd;
        private List<HistoryDto> data;
        private List<HistoryDto> currentData;

        public HistoryForm(string staffId)
        {
            InitializeComponent();
            this.Load += HistoryForm_Load;
            this.FormClosed += HistoryForm_FormClosed;
            initData();
            initDataGridView(data);

        }

        private void HistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            initDateTimePicker();
            initComboBox();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex <0)
            {
                return;
            }
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(columnName == nameof(HistoryDto.action))
            {
                var orderNo = dataGridView1.Rows[e.RowIndex].Cells[nameof(HistoryDto.orderNo)].Value;
                MessageBox.Show(orderNo.ToString());
                FlowerDetail form = new FlowerDetail(orderNo);
                form.Show();
                this.Hide();
            }
            
        }

        private void initComboBox()
        {
            List<object> statusList = new List<object>
            {
                "All",
                "Prepare",
                "Pending"
            };
            List<string> searchList = new List<string>
            {
                "Order Date",
                "Delivery Date"
            };
            cb_status.DataSource = statusList;
            cb_search_by.DataSource = searchList;
            cb_status.SelectedIndex = 0;
            cb_search_by.SelectedIndex = 0;
            cb_status.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_search_by.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initDateTimePicker()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // Load datagridview datasource
        private void button1_Click(object sender, EventArgs e)
        {
            cb_status.SelectedIndexChanged += Cb_status_SelectedIndexChanged;
            cb_search_by.SelectedIndexChanged += Cb_search_by_SelectedIndexChanged;
            memoryDate();

            // Update current data to result

            // Verify status condition
            if (status == StatusEnum.All)
            {
                currentData = data;
            }
            else
            {
                currentData = data
                    .Where(x => x.status == status.ToString().Replace("_", " "))
                    .ToList();
            }

            // Verify search by condition
            if (searchBy.Equals(SearchByEnum.Order_Date))
            {
                currentData = currentData
                    .Where(x => x.orderDate >= dateStart &&
                    x.deliveryDate < dateEnd)
                     .OrderBy(x => x.orderDate)
                     .ToList();
            }
            else if (searchBy.Equals(SearchByEnum.Delivery_Date))
            {
                currentData = currentData
                    .Where(x => x.orderDate >= dateStart &&
                    x.deliveryDate < dateEnd)
                    .OrderBy(x => x.deliveryDate)
                    .ToList();
            }
            else
            {
                MessageBox.Show("ERROR");
                return;
            }



            // Init datagridview
            initDataGridView(currentData);

        }

        private void initDataGridView(List<HistoryDto> result)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result;

            // Change header text
            dataGridView1.Columns[nameof(HistoryDto.orderNo)].HeaderText = "Order No.";
            dataGridView1.Columns[nameof(HistoryDto.orderDate)].HeaderText = "Order Date";
            dataGridView1.Columns[nameof(HistoryDto.deliveryDate)].HeaderText = "Delivery";
            dataGridView1.Columns[nameof(HistoryDto.storeName)].HeaderText = "Store";
            dataGridView1.Columns[nameof(HistoryDto.totalAmount)].HeaderText = "Total";
            dataGridView1.Columns[nameof(HistoryDto.status)].HeaderText = "Status";
            dataGridView1.Columns[nameof(HistoryDto.action)].HeaderText = "Action";

            dataGridView1.ReadOnly = true;
        }

        private void initData()
        {
            using (var db = new Session1Entities())
            {
                var data = db.PurchaseOrders
                    .AsEnumerable()
                    .Select(x => new HistoryDto
                    {
                        orderNo = x.OrderNo,
                        orderDate = x.OrderDate,
                        deliveryDate = x.DeliveryDate,
                        storeName = x.Store.StoreName,
                        totalAmount = Convert.ToDouble(x.TotalAmount),
                        status = x.Status,
                        action = "View Detail"
                    })
                    .ToList();

                if (data.Count == 0)
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                this.data = data;
            }
        }

        private void memoryDate()
        {
            dateStart = dateTimePicker1.Value;
            dateEnd = dateTimePicker2.Value;
        }

        private void Cb_search_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_search_by.SelectedIndex == 0)
            {
                searchBy = SearchByEnum.Order_Date;
            }
            else if (cb_search_by.SelectedIndex == 1)
            {
                searchBy = SearchByEnum.Delivery_Date;
            }
            else
            {
                return;
            }
        }

        private void Cb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_status.SelectedIndex == 0)
            {
                status = StatusEnum.All;
            }
            else if (cb_status.SelectedIndex == 1)
            {
                status = StatusEnum.Prepare;
            }
            else if (cb_status.SelectedIndex == 2)
            {
                status = StatusEnum.Pending_Delivery;
            }
            else if (cb_status.SelectedIndex == 3)
            {
                status = StatusEnum.Completed;

            }

            else
            {
                return;
            }
        }
    }
}
