using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.data.models;
using S2.ui;
using S2.ui.main.control;
using S2.util;

namespace S2.controls
{
    public partial class DeclarationControl : UserControl
    {
        private const int PAGE_LENGTH = 10;
        private List<DeclarationRow> allDataOfDeclaration = new List<DeclarationRow>();
        private List<DeclarationRow> filteredPages = new List<DeclarationRow>();
        private int currentPage = 1;
        private int totalPages = 1;

        public DeclarationControl()
        {
            InitializeComponent();

            loadData();


            initControl();
            initListener();


            refreshPageData();
            
        }

        private void refreshPageData()
        {
            filterPage();
            showPage();
        }

        private void initControl()
        {
            intComboBox();
        }

        private void intComboBox()
        {
            initComboBoxDeclarationStatus();
            // set combo boxcontainer number
            initComboBoxContainerNumber();
            initComboBoxVoyageNumber();
        }

        private void initComboBoxDeclarationStatus()
        {
            // combo box declaration
            cb_declaration_status.Items.AddRange(new string[]
            {
                "All", StatusUtils.Pending, StatusUtils.Rejected, StatusUtils.Approved
            });
            cb_declaration_status.SelectedIndex = 0;
            //
        }

        private void initComboBoxContainerNumber()
        {
            using(var db = new S2DBEntities())
            {
                var dataOfContainerNumber = db.containers
                    .Select(x => x.container_number)
                    .ToList();

                cb_container_number.Items.Add("All");
                cb_container_number.Items.AddRange(dataOfContainerNumber.ToArray());
                cb_container_number.SelectedIndex = 0;
            }
        }

        private void initListener()
        {
            cb_voyage_number.SelectedIndexChanged += (s, e) => refreshContainerNumbers();
            tb_page.KeyPress += tb_page_KeyPress;
        }

        private void tb_page_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            int page;
            try
            {
                page = Convert.ToInt32(tb_page.Text.Trim());
                goToPage(page);
            }
            catch
            {
                MessageBox.Show("Please enter number,does not enter string");
                return;
            }
            e.Handled = true;
        }


        public void initComboBoxVoyageNumber()
        {
            using (var db = new S2DBEntities())
            {
                DateTime threeDayAgo = DateTime.Now.AddDays(-2);

                var dataOfVoyageNumberList = db.voyages
                    .Where(x=>x.actual_arrival_time >= threeDayAgo)
                    .Select(x => x.voyage_number)
                    .ToList();
                cb_voyage_number.Items.Add("All");
                cb_voyage_number.Items.AddRange(dataOfVoyageNumberList.ToArray());
                cb_voyage_number.SelectedIndex = 0;
            }
        }



        private void refreshContainerNumbers()
        {
            using(var db = new S2DBEntities())
            {
                string voyage = getFilterValue(cb_voyage_number);

                cb_container_number.Items.Clear();
                cb_container_number.Items.Add("All");

                var dataOfContainerNumber = db.containers
                    .Where(x => x.voyage_number == voyage || voyage.Length == 0)
                    .Select(x => x.container_number)
                    .ToList();

                cb_container_number.Items.Clear();
                cb_container_number.Items.Add("All");
                cb_container_number.Items.AddRange(dataOfContainerNumber.ToArray());
                cb_container_number.SelectedIndex = 0;
            }
        }


        private string getFilterValue(Control control)
        {
            string text = control.Text.Trim();
            if ("All".Equals(text))
            {
                return "";
            }
            return text;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            filterPage();
            showPage();
        }

        public void loadData()
        {
            using (var db = new S2DBEntities())
            {
                var dataOfPage = db.declarations
                    .Select(x => new DeclarationRow
                    {
                        voyageNumber = x.container.voyage_number,
                        declarationId = x.id,
                        cargoAmount = x.cargo_amount,
                        dutyPayable = x.duty_payable ?? 0,
                        declarationTime = x.declaration_time,
                        status = x.declaration_status.status,
                        hsCode = x.hs_code,
                        tradeMode = x.trade_mode1.name,
                        originCountry = x.country_of_origin,
                        containerNumber = x.container.container_number,
                        cargoOwner = x.container.cargo_owner.username,
                        changeTime = db.declaration_status_change
                            .Where(c=>c.declaration_id == x.id)
                            .Select(c => c.change_time)
                            .FirstOrDefault()
                    })
                    .ToList();
                allDataOfDeclaration = dataOfPage;
                refreshPageData();
            }
        }

        private void filterPage()
        {
            string voyage = getFilterValue(cb_voyage_number);
            string container = getFilterValue(cb_container_number);
            string status = getFilterValue(cb_declaration_status);
            string keywordDeclarationId = getFilterValue(tb_declaration_id);

            var filterPage = allDataOfDeclaration
                .Where(x => (voyage.Length == 0 || x.voyageNumber == voyage)
                && (container.Length == 0 || x.containerNumber == container)
                && (status.Length == 0 || x.status == status)
                && (keywordDeclarationId.Length == 0 || x.declarationId.Contains(keywordDeclarationId)))
                .OrderBy(x=>statusOrderMap(x.status))
                .ToList();

            filteredPages = filterPage;
            

            totalPages = Math.Max(1, (filteredPages.Count + PAGE_LENGTH - 1) / PAGE_LENGTH);
            currentPage = 1;

            lb_x_records_found.Text = filteredPages.Count + " Records Found";
        }

        private int statusOrderMap(string status)
        {
            if (status == StatusUtils.Pending) return 0;
            if (status == StatusUtils.Approved) return 1;
            if(status == StatusUtils.Rejected) return 2;
            return -1;
        }

        private void showPage()
        {
            flowLayoutPanel1.Controls.Clear();

            var pageRows = filteredPages
                .Skip((currentPage - 1) * PAGE_LENGTH)
                .Take(PAGE_LENGTH)
                .ToList();

            foreach(var item in pageRows)
            {
                var card = new DeclarationUserControl(item);
                flowLayoutPanel1.Controls.Add(card);
            }

            //foreach (var row in pageRows)
            //{
            //    var card = new DeclarationUserControl(row,
            //        () => showDeclarationDetail(row),
            //        () => MessageBox.Show("Rejected Reason: " + row.rejectReason));

            //    flowLayoutPanel1.Controls.Add(card);
            //}

            tb_page.Text = currentPage.ToString();
            lb_page_x_x.Text = "Page: " + currentPage + "/" + totalPages;
        }

        private void showDeclarationDetail(DeclarationRow row)
        {
            if (row.status == StatusUtils.Pending)
            {
                new DeclarationDetailForm(row).ShowDialog(ParentForm);
            }
            else
            {
                MessageBox.Show("Does not realized");
            }
        }


        private void goToPage(int page)
        {
            currentPage = Math.Max(1, Math.Min(page, totalPages));
            showPage();
        }

        private void btn_first_Click(object sender, EventArgs e) { goToPage(1); }
        private void btn_prev_Click(object sender, EventArgs e) { goToPage(currentPage - 1); }
        private void btn_next_Click(object sender, EventArgs e) { goToPage(currentPage + 1); }
        private void btn_last_Click(object sender, EventArgs e) { goToPage(totalPages); }



    }
}
