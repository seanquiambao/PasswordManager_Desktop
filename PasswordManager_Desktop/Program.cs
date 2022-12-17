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

        public static SQLDatabase SQL;
        public static SQLNonQuery NonQuery;
        public static SQLQuery Query;
        public static Hashing HashAlgorithm;
        [STAThread]
        static void Main()
        {
            SQL = new SQLDatabase();
            NonQuery = new SQLNonQuery();
            Query = new SQLQuery();
            HashAlgorithm = new Hashing();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
