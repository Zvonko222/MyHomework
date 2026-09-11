using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Session3.Tools
{
    public class DBHelper
    {
        private static string connStr = "server=localhost;database=WorldSkillsBooking;uid=sa;pwd=123;";

        public static DataTable executeQuery(string sql)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
                adapter.Fill(table);
                return table;
            }
        }
        public static bool executeNonQuery(string sql)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                if(result != 0)
                {
                     return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}