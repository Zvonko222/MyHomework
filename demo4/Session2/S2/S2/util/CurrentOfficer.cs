namespace S2.util
{
    /// <summary>
    /// Current logged in customs officer (set by LoginForm).
    /// </summary>
    public static class CurrentOfficer
    {
        public static string JobNumber;
        public static string FirstName;
        public static string LastName;
        public static string RoleName;

        public static string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public static string Title(string page)
        {
            return "SH Port Customs-" + page + "(" + FullName + "-" + RoleName + ")";
        }
    }
}
