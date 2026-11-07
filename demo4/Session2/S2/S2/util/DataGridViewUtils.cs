using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2.util
{
    internal class DataGridViewUtils
    {
        public  void addLinkColumn(DataGridView grid, string name, string headertText)
        {
            var column = new DataGridViewLinkColumn
            {
                Name = name,
                HeaderText = headertText
            };
            grid.Columns.Add(column);
        }
        public void addCheckBoxColumn(DataGridView grid,string name, string headerText)
        {
            var checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = name,
                HeaderText = headerText
            };
            grid.Columns.Add(checkBoxColumn);
        }

    }
}
