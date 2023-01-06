using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace PasswordManager_Desktop.src
{
    public class ReadingWriting
    {

        public void createCSVFile(string filepath, string masterUser)
        {
            filepath += $"\\{masterUser}Database.csv";

            DataTable data = Program.Query.FetchTable(masterUser);
            DataTable AESData = Program.Query.GetDataFromTable(masterUser, "username", "UserDatabase");
            DataRow AESRow = AESData.Rows[0];
            byte[] key = (byte[])AESRow[3];
            byte[] iv = (byte[])AESRow[4];
            

            foreach (DataRow row in data.Rows)
            {
                try
                {
                    string title = row[1].ToString();
                    string username = row[2].ToString();
                    string email = row[4].ToString();
                    byte[] cipherPassword = (byte[])row[3];
                    string plainPassword = Program.AESAlgorithm.DecryptStringFromBytes(cipherPassword, key, iv);
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                    {
                        file.WriteLine($"{title}, {username}, {plainPassword}, {email}");
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Program Error: ", ex);
                }
            }

        }

        public void ReadFromCSVFile(string filepath, string masterUser)
        {
            
            try
            {
                using (var reader = new StreamReader(@filepath))
                {
                    DataTable data = Program.Query.GetDataFromTable(masterUser, "username", "UserDatabase");
                    DataRow row = data.Rows[0];

                    byte[] key = (byte[])row[3];
                    byte[] iv = (byte[])row[4];
                    while (!reader.EndOfStream)
                    {
                        var lines = reader.ReadLine();
                        var values = lines.Split(',');

                        string plainTextPassword = values[2].ToString();
                        byte[] cipherText = Program.AESAlgorithm.EncryptStringToBytes(plainTextPassword, key, iv);
                        string[] columns = { values[0].ToString(), values[1].ToString(), values[3].ToString() };
                        Program.NonQuery.InsertTable(columns, cipherText, masterUser);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Program Error: ", ex);
            }

            
        }

    }
}
