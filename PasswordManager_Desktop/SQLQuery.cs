using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PasswordManager_Desktop
{
    class SQLQuery
    {

        public DataTable GetDataFromTable(string target, string column, string tableName)
        {
            var data = new DataTable();

            SQLDatabase.conn.Open();

            string s = $"SELECT * FROM {tableName} WHERE {column} = '{target}'";
            SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            SQLDatabase.conn.Close();

            return data;
        }

        public DataTable FetchTable(string tableName)
        {
            var data = new DataTable();

            SQLDatabase.conn.Open();
            string s = $"SELECT * FROM {tableName}";
            SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);
            SQLDatabase.conn.Close();

            return data;
        }

        public bool ExistInTable(string target, string column, string tableName)
        {
            SQLDatabase.conn.Open();

            bool existence = false;

            string s = $"SELECT * FROM {tableName} WHERE {column} = '{target}';";
            SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows) existence = true;

            SQLDatabase.conn.Close();

            return existence;
        }
    }
}
