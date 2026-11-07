using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace S2.util
{
   
    public static class UiUtils
    {

        public static void setCenter(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void DisableCells(DataGridViewRow row, params string[] columnNames)
        {
            foreach (string name in columnNames)
            {
                row.Cells[name] = new DataGridViewTextBoxCell();
            }
        }


    }
}
