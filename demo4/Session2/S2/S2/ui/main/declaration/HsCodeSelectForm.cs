using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using S2.data.db.model;
using S2.util;

namespace S2.ui
{
    public partial class HsCodeSelectForm : Form
    {
        public string SelectedHsCode { get; private set; }

        public HsCodeSelectForm()
        {
            InitializeComponent();

            initControl();
            loadData();
        }

        private void initControl()
        {
            UiUtils.setCenter(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadData()
        {
            using (var db = new S2DBEntities())
            {
                var data = db.harmonized_system
                    .AsNoTracking()
                    .OrderBy(h => h.hs_code)
                    .Select(h => new
                    {
                        h.hs_code,
                        h.hs_description
                    })
                    .ToList();

                foreach (var hs in data)
                {
                    dgvHsCodes.Rows.Add(hs.hs_code, hs.hs_description);
                }
            }
        }

        private void SelectRow(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvHsCodes.Columns[e.ColumnIndex].Name != "col_select")
            {
                return;
            }

            SelectedHsCode = Convert.ToString(
                dgvHsCodes.Rows[e.RowIndex].Cells["col_code"].Value);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
