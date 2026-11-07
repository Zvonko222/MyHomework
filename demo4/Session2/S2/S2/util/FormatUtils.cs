using System;
using System.Windows.Forms;

namespace S2.util
{
    internal static class FormatUtils
    {
        public static bool isEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
        public static string getText(Control control)
        {
            string text = control.Text.ToString().Trim();
            return text;
        }
    }
}
