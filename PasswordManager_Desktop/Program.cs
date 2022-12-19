using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PasswordManager_Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static string username;
        public static SQLDatabase SQL;
        public static SQLNonQuery NonQuery;
        public static SQLQuery Query;
        public static Hashing HashAlgorithm;
        public static Encryption AESAlgorithm;
        [STAThread]
        static void Main()
        {
            SQL = new SQLDatabase();
            NonQuery = new SQLNonQuery();
            Query = new SQLQuery();
            HashAlgorithm = new Hashing();
            AESAlgorithm = new Encryption();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        public static void SetUsername(string newUsername)
        {
            username = newUsername;
        }

        public static string GetUsername()
        {
            return username;
        }
    }
}
