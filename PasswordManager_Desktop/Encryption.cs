using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager_Desktop
{
    class Encryption
    {

        public byte[] EncryptStringToBytes(string plainText)
        {
            Aes myAes = Aes.Create();
            byte[] Key = myAes.Key;
            byte[] IV = myAes.IV;
            if (plainText == null || plainText.Length <= 0) throw new ArgumentNullException("plainText");
            checkForArguments(Key, IV);


            byte[] encrypted = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using(MemoryStream msEncrypt = new MemoryStream())
                {
                    using(CryptoStream csEncrpyt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter swEncrypt = new StreamWriter(csEncrpyt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }

            }

            return encrypted;
        }

        public string DecryptStringFromBytes(byte[] cipherText)
        {
            Aes myAes = Aes.Create();
            byte[] Key = myAes.Key;
            byte[] IV = myAes.IV;
            if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("cipherText");
            checkForArguments(Key, IV);


            string decrypted = null;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }

                    }
                }

            }

            return decrypted;
        }

        private void checkForArguments(byte[] Key, byte[] IV)
        {
            if (Key == null || Key.Length <= 0) throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0) throw new ArgumentNullException("IV");
        }
    }
}
