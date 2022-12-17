using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;


namespace PasswordManager_Desktop
{
    public class SQLDatabase
    {
        public static SqlConnection conn;
        string connectionString;

        public SQLDatabase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PasswordManager_Desktop.Properties.Settings.TestDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Unable to connect to database\n");
                _throwError(ex);
            }
            conn.Close();
        }

        public static void _throwError(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                Console.WriteLine($"Index #{i} \n Error:{exception.Errors[i].ToString()} \n");
            }
        }

        

    }
}
