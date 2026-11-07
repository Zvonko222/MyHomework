using System.Windows.Forms;

namespace S2.util
{
    /// <summary>
    /// Common message dialogs: secondary confirm, info, warn.
    /// </summary>
    public static class MsgUtils
    {
        public static bool Confirm(string msg)
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }
    }
}
