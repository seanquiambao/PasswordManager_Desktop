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
        public void InsertTable(string[] columns, byte[] key, byte[] iv,string tableName)
        {
            SQLDatabase.conn.Open();
            string s = $"INSERT INTO {tableName} VALUES('{columns[0]}', '{columns[1]}', @key, @iv);";

            try
            {
                SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@iv", iv);
                cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                SQLDatabase._throwError(ex);
            }
            finally
            {
                SQLDatabase.conn.Close();
            }
        }

        public void InsertTable(string[] columns, byte[] password, string tableName)
        {
            SQLDatabase.conn.Open();
            string s = $"INSERT INTO {tableName} VALUES('{columns[0]}', '{columns[1]}', @password, '{columns[2]}');";

            try
            {
                SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                SQLDatabase._throwError(ex);
            }
            finally
            {
                SQLDatabase.conn.Close();
            }
            
            
        }

        public void DeleteDataFromTable(string target, string column, string tableName)
        {
            SQLDatabase.conn.Open();
            string s = $"DELETE FROM {tableName} WHERE {column} = '{target}';";
            Console.WriteLine(s);
            _executeNonQueryStatement(s);
            SQLDatabase.conn.Close();
        }

        public void UpdateUserAccountRow(string target, string[] modifiedValues, byte[] modifiedPassword, string tableName)
        {
            SQLDatabase.conn.Open();
            string s = $"UPDATE {tableName} SET " +
                $"Title = '{modifiedValues[0]}', " +
                $"Username = '{modifiedValues[1]}', " +
                $"Password = @password, " +
                $"URL = '{modifiedValues[2]}' " +
                $"WHERE Title = '{target}'";

            Console.WriteLine(s);
            try
            {
                SqlCommand cmd = new SqlCommand(s, SQLDatabase.conn);
                cmd.Parameters.AddWithValue("@password", modifiedPassword);
                cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                SQLDatabase._throwError(ex);
            }
            finally
            {
                SQLDatabase.conn.Close();
            }
        }
        
        public void CreateUserTable(string username)
        {
            SQLDatabase.conn.Open();
            string s = $"CREATE TABLE [dbo].[{username}](" +
                $"[Id] INT IDENTITY (1,1) NOT NULL, " +
                $"[Title] VARCHAR(50)," +
                $"[Username] VARCHAR(50) NOT NULL, " +
                $"[Password] VARBINARY(1024) NOT NULL, " +
                $"[URL] VARCHAR(MAX) NOT NULL," +
                $"PRIMARY KEY CLUSTERED ([Id] ASC));";
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
