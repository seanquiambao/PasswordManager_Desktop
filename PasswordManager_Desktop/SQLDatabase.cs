using System;
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

        public SQLDatabase()
        {
            conn = new SqlConnection("Data Source = database.db; Version = 3; New = True; Compression = True;");
            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("Unable to connect to database");
            }
        }

        void CreateUserDatabaseTable()
        {
            string s = "CREATE TABLE IF NOT EXIST 'User Database'(username STRING, password STRING, iterations INT)";
            ExecuteNonQueryCommand(s);
        }

        void InsertTable(string[] columns, string tableName)
        {
            string s = $"INSERT INTO '{tableName}' VALUES(";
            for(int i = 0; i < columns.Length; ++i)
            {
                s += $"'{columns[i]}', ";
            }
            s += ");";

            ExecuteNonQueryCommand(s);
        }

        void ExecuteNonQueryCommand(string command)
        {
            SqlCommand cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();
        }

    }
}
