using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PasswordManager_Desktop
{
    class SQLNonQuery
    {
        public void InsertTable(string[] columns, string tableName)
        {
            SQLDatabase.conn.Open();
            string s = $"INSERT INTO {tableName} VALUES(";
            for (int i = 0; i < columns.Length; ++i)
            {
                s += $"'{columns[i]}'";
                if (i != (columns.Length) - 1) s += ", ";
            }
            s += ");";

            Console.WriteLine(s);

            _executeNonQueryStatement(s);
            SQLDatabase.conn.Close();
        }

        

        private void _executeNonQueryStatement(string command)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(command, SQLDatabase.conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                SQLDatabase._throwError(ex);
            }

        }
    }
}
