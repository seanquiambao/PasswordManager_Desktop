using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager_Desktop
{
    interface ManagerTables
    {
    }

    public class UserDatabaseTable : ManagerTables
    {
        public string username;
        public byte[] password;
    }

    public class UserAccountTable : ManagerTables
    {
        public string title;
        public string username;
        public byte[] password;
        public string url;
    }
}
