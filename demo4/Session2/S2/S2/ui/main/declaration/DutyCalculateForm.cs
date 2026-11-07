using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.util;

namespace S2.ui
{
    /// <summary>
    /// Automatic duty calculation: adjust HS Code, country, trade mode and amount.
    /// </summary>
    public partial class DutyCalculateForm : Form
    {
        private readonly string declarationId;

        private int quantity;
        private string hsCode;
        private string countryCode;
        private int tradeModeId;

        public DutyCalculateForm() : this(null)
        {
        }

        public DutyCalculateForm(string declarationId)
        {
            this.declarationId = declarationId;
            InitializeComponent();

            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || string.IsNullOrEmpty(declarationId))
            {
                return;
            }

            initControl();
            loadData();
        }

        private void initControl()
        {
            UiUtils.setCenter(this);
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDuty();
        }

        private void cbTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDuty();
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            refreshDuty();
        }

        private void linkHs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectHsCode();
        }

        private void linkRecalc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            recalculateAmount();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData()
        {
            using (var db = new S2DBEntities())
            {
                var item = db.declarations
                    .AsNoTracking()
                    .Where(d => d.id == declarationId)
                    .Select(d => new
                    {
                        d.quantity,
                        d.hs_code,
                        d.country_of_origin,
                        d.trade_mode,
                        d.cargo_amount,
                        unitName = d.unit.name
                    })
                    .FirstOrDefault();
                if (item == null) return;

                quantity = item.quantity;
                hsCode = item.hs_code;
                countryCode = item.country_of_origin;
                tradeModeId = item.trade_mode;

                lblQuantity.Text = "Quantity: " + quantity + " " + item.unitName;
                showHsCode();
                tbAmount.Text = item.cargo_amount.ToString("0.00");

                loadCountries(db);
                loadTradeModes(db);

                refreshDuty();
            }
        }

        private void loadCountries(S2DBEntities db)
        {
            var data = db.countries
                .AsNoTracking()
                .OrderBy(c => c.name)
                .Select(c => new OptionItem
                {
                    Code = c.country_code,
                    Name = c.name,
                    Rate = c.duty_rate
                })
                .ToList();

            cbCountry.Items.Clear();
            cbCountry.Items.AddRange(data.Cast<object>().ToArray());
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Code";
            cbCountry.SelectedItem = data.FirstOrDefault(c => c.Code == countryCode);
        }

        private void loadTradeModes(S2DBEntities db)
        {
            var data = db.trade_mode
                .AsNoTracking()
                .OrderBy(t => t.id)
                .Select(t => new OptionItem
                {
                    Id = t.id,
                    Name = t.name
                })
                .ToList();

            cbTrade.Items.Clear();
            cbTrade.Items.AddRange(data.Cast<object>().ToArray());
            cbTrade.DisplayMember = "Name";
            cbTrade.ValueMember = "Id";
            cbTrade.SelectedItem = data.FirstOrDefault(t => t.Id == tradeModeId);
        }

        private void selectHsCode()
        {
            var form = new HsCodeSelectForm();
            if (form.ShowDialog() != DialogResult.OK) return;

            hsCode = form.SelectedHsCode;
            showHsCode();
            refreshDuty();
        }

        private void showHsCode()
        {
            lb_hs_code.Text = "HS Code: " + (hsCode ?? "");
        }

        private void recalculateAmount()
        {
            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2);

            using (var db = new S2DBEntities())
            {
                var approvedIds = db.declaration_status_change
                    .AsNoTracking()
                    .Where(c => c.declaration_status.status == StatusUtils.Approved
                        && c.change_time >= start)
                    .Select(c => c.declaration_id)
                    .Distinct()
                    .ToList();

                var unitPrices = db.declarations
                    .AsNoTracking()
                    .Where(d => approvedIds.Contains(d.id)
                        && d.hs_code == hsCode
                        && d.country_of_origin == countryCode
                        && d.trade_mode == tradeModeId
                        && d.quantity > 0)
                    .Select(d => d.cargo_amount / d.quantity)
                    .ToList();

                if (unitPrices.Count == 0)
                {
                    MessageBox.Show("No approved declaration found to recalculate");
                    return;
                }

                decimal avgUnitPrice = unitPrices.Average();
                tbAmount.Text = DutyUtils.Round2(avgUnitPrice * quantity).ToString("0.00");
            }
        }

        private void refreshDuty()
        {
            var selectedCountry = cbCountry.SelectedItem as OptionItem;
            var selectedTrade = cbTrade.SelectedItem as OptionItem;
            if (selectedCountry != null) countryCode = selectedCountry.Code;
            if (selectedTrade != null) tradeModeId = selectedTrade.Id;

            decimal amount;
            if (!decimal.TryParse(tbAmount.Text.Trim(), out amount)
                || amount <= 0
                || selectedCountry == null || selectedTrade == null)
            {
                lblDuty.Text = "-";
                return;
            }

            using (var db = new S2DBEntities())
            {
                decimal? hsRate = db.harmonized_system
                    .AsNoTracking()
                    .Where(h => h.hs_code == hsCode)
                    .Select(h => (decimal?)h.duty_rate)
                    .FirstOrDefault();
                if (!hsRate.HasValue)
                {
                    lblDuty.Text = "-";
                    return;
                }

                decimal duty = DutyUtils.CalcDuty(hsRate.Value, selectedCountry.Rate,
                    selectedTrade.Name, amount);
                lblDuty.Text = duty.ToString("0.00");
            }
        }

        private void submit()
        {
            string normalizedHsCode = (hsCode ?? "").Trim();
            var selectedCountry = cbCountry.SelectedItem as OptionItem;
            var selectedTrade = cbTrade.SelectedItem as OptionItem;

            if (normalizedHsCode.Length == 0)
            {
                MessageBox.Show("Please select an HS Code");
                return;
            }
            if (selectedCountry == null)
            {
                MessageBox.Show("Please select a country of origin");
                return;
            }
            if (selectedTrade == null)
            {
                MessageBox.Show("Please select a trade mode");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(tbAmount.Text.Trim(), out amount) || amount <= 0)
            {
                MessageBox.Show("Cargo amount must be a positive number");
                return;
            }
            if (!MsgUtils.Confirm("Are you sure to update the declaration and approve it?")) return;

            using (var db = new S2DBEntities())
            {
                var item = db.declarations.FirstOrDefault(d => d.id == declarationId);
                decimal? hsRate = db.harmonized_system
                    .AsNoTracking()
                    .Where(h => h.hs_code == normalizedHsCode)
                    .Select(h => (decimal?)h.duty_rate)
                    .FirstOrDefault();
                if (item == null || !hsRate.HasValue)
                {
                    MessageBox.Show("The declaration data is incomplete and can not be submitted");
                    return;
                }

                item.hs_code = normalizedHsCode;
                item.country_of_origin = selectedCountry.Code;
                item.trade_mode = selectedTrade.Id;
                item.cargo_amount = amount;
                item.duty_payable = DutyUtils.CalcDuty(
                    hsRate.Value, selectedCountry.Rate, selectedTrade.Name, amount);
                StatusUtils.setDeclaration(db, item, StatusUtils.Approved,
                    "Auto duty calculated and approved");
                db.SaveChanges();
            }

           MessageBox.Show("The declaration has been updated and approved");
            Close();
        }

        private sealed class OptionItem
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public decimal Rate { get; set; }
        }
    }
}
