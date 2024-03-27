using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ITPCA_CT._2022.Y2M9F2_Claremont_Elvis_Chimuse
{
    class Accounts
    {
        private static List<Accounts> accountUsers = new List<Accounts>();

        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        string Pin { get; set; }
        public double Balance { get; set; }

        //Consructor
        public Accounts(string accountName, string accountNumber, string pin, double balance)
        {
            AccountName = accountName;
            AccountNumber = accountNumber;
            Pin = pin;
            Balance = balance;
        }

        public static void AddingUser(Accounts users)
        {
            accountUsers.Add(users);//Adds a user into the list
        }

        public static bool Authenticate(string accountNum, string pin)
        {

            Accounts users = accountUsers.FirstOrDefault(u => u.AccountNumber == accountNum);
            if (users != null && users.Pin == pin)
            {
                Console.WriteLine("Welcome back " + users.AccountName);
                return true;
            }
            else
            {
                Console.WriteLine("Wrong details. Invalid account");
                return false;
            }
        }

        public static Accounts GetUserByAccountNumber(string accountNumber)
        {
            return accountUsers.FirstOrDefault(u => u.AccountNumber == accountNumber);
        }

        public static string Encryption(string key, string plainText)//From JavatPoint ,site webiste
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string Decryption(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}

