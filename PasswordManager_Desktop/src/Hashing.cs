using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PasswordManager_Desktop
{
    class Hashing
    {

        public string PasswordHashing(string password)
        {
            byte[] tmpSource;
            byte[] tmpHash;

            tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            string savedPasswordHash = ByteArrayToString(tmpHash);


            return savedPasswordHash;
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
