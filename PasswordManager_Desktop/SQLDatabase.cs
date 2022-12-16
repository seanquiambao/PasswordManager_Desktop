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
    class SQLDatabase
    {
        SqlConnection conn;
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

            CreateUserDatabaseTable();
        }

        void CreateUserDatabaseTable()
        {
            string s = "CREATE TABLE IF NOT EXISTS 'User Database'(username STRING, password STRING, iterations INT)";
            _executeNonQueryStatement(s);
        }

        public void InsertTable(string[] columns, string tableName)
        {
            string s = $"INSERT INTO '{tableName}' VALUES(";
            for(int i = 0; i < columns.Length; ++i)
            {
                s += $"'{columns[i]}', ";
            }
            s += ");";

            _executeNonQueryStatement(s);
        }

        private void _executeNonQueryStatement(string command)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                _throwError(ex);
            }
            
        }

        private void _throwError(SqlException exception)
        {
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                Console.WriteLine($"Index #{i} \n Error:{exception.Errors[i].ToString()} \n");
            }
        }

        

    }
}
