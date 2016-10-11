using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using Text_Bases_RPG.Utility;

namespace ConsoleApplication1
{
    static class Database
    {
        private static string server = @".\SQLEXPRESS";
        private static string database = "TheGriffinContract";
        private static SqlConnection _connection;

        public static void Connect()
        {
            _connection = new SqlConnection("Server="+ server +";Database="+ database +";Trusted_Connection=True;");
            Text.textSpeed = 40;
            
            try
            {
                _connection.Open();
            }
            catch (SqlException ex)
            {
                Text.Error(ex.Message);
                Thread.CurrentThread.Abort();
            }
        }

        public static SqlDataReader Query(string query)
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(query, _connection);
                myReader = myCommand.ExecuteReader();
                return myReader;
            }
            catch (SqlException e)
            {
                Text.Error(e.Message);
                return null;
            }

        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
