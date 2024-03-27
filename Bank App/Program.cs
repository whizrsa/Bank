using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ITPCA_CT._2022.Y2M9F2_Claremont_Elvis_Chimuse
{
    class Program
    {
        static void Main(string[] args)
        {
            int tries = 3;  //User gets 3 attemps to enter correct user details else program breaks

            Accounts[] accountUsers = AccountUsers();

            foreach (var user in accountUsers)
            {
                Accounts.AddingUser(user);
            }

            var key = "b14ca5898a4e4133bbce2ea2315a1916";

            IUserTransaction userTransaction = new PerfomTransactions();
            try
            {
                while (tries > 0)//user gets 3 tries to enter their password
                {
                    UserLogin();
                    Console.WriteLine("Enter your account Number");
                    var accountNum = UserInput();

                    Console.WriteLine("Please enter your Password/pin: ");
                    var password = UserInput();//var takes any variable


                    string encryption = Accounts.Encryption(key, password);
                    Console.WriteLine("Encrypted!!");

                    string decryption = Accounts.Decryption(key, encryption);
                    Console.WriteLine("Decrypted");

                    Console.Clear();

                    bool AuthenticatedUser = Accounts.Authenticate(accountNum, decryption);

                    if (AuthenticatedUser)
                    {
                        Accounts User = Accounts.GetUserByAccountNumber(accountNum);//the rest of the users details will be displayed
                        UserOptions(userTransaction, User);

                    }
                    else
                    {
                        tries--;
                        Console.WriteLine("Wrong details. You have " + tries + " Remaining");

                    }

                    if (tries == 0)
                    {
                        Console.WriteLine("You have run out of attemps!!!");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unforseen Error has Occured thus program crashed");
            }

            Console.ReadKey();

        }
        public static Accounts[] AccountUsers()//declare arrays and store account data
        {
            Accounts[] AccountUsers = new Accounts[]
        {
                new Accounts("Elvis", "1234", "2019", 28904.0),
                new Accounts("Mace", "5678", "9102", 43783.90),
                new Accounts("Sergio", "1020", "2345", 2345.98)
        };
            return AccountUsers;
        }

        public static void UserLogin()
        {
            Console.WriteLine("                  ");
            Console.WriteLine("****Welcome****");
            Console.WriteLine("****Log In*****");
            Console.WriteLine("                  ");
        }
        public static string UserInput()
        {
            return Console.ReadLine();
        }

        public static void UserOptions(IUserTransaction userTransaction, Accounts user)
        {
            var choice = "";
            try
            {
                do
                {
                    Console.WriteLine("1. Withdraw Funds\t\n2. Deposit\t\n3. Display\t\n4. Transfer Funds\t\n5. Log Out");
                    Console.WriteLine("Type -1 to Exit Program");
                    Console.WriteLine("Select Option");
                    choice = UserInput();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Enter withdrawal amout!!");
                            var withdraw = Convert.ToDouble(UserInput());
                            userTransaction.WithDrawFunds(user, withdraw);

                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Enter the amount to deposit");
                            var deposit = Convert.ToDouble(UserInput());
                            userTransaction.DepositFunds(user, deposit);
                            break;
                        case "3":
                            userTransaction.DisplayBalance(user);
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Enter the balance to be transferred");
                            var tranferFunds = Convert.ToDouble(UserInput());
                            userTransaction.TransferFunds(user, tranferFunds);
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Successfully Logged out");
                            LogOut(ref choice);
                            break;
                        default:
                            if (choice == "-1")
                            {
                                Console.WriteLine("Logged out!!");
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry");
                            }

                            break;
                    }
                } while (!choice.Equals("-1", StringComparison.OrdinalIgnoreCase));//Check C# Corner to confirm again
            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid input!!");
            }

        }

        public static void LogOut(ref string choice)
        {
            choice = "-1";//just random number

            do
            {
                System.Environment.Exit(0);//manipulate current environment
            } while (choice == "-1");
        }

    }
}

