using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPCA_CT._2022.Y2M9F2_Claremont_Elvis_Chimuse
{
    class PerfomTransactions : IUserTransaction
    {
        public void DisplayBalance(Accounts User)
        {
            Console.Clear();
            Console.WriteLine(" \t\n");
            Console.WriteLine("Account Name: " + User.AccountName);
            Console.WriteLine("Account Number: " + User.AccountNumber);
            Console.WriteLine("Balance: " + User.Balance);
            Console.WriteLine(" \t\n");
        }

        public void DepositFunds(Accounts User, double balance)
        {
            if (balance <= 0)
            {
                Console.WriteLine("You entred an Invalid amount. Please enter a positive amount!!");
                return;
            }

            User.Balance += balance;
            Console.WriteLine("You have successfully deposited. New Balance: " + User.Balance + "\t\n");
        }

        public void WithDrawFunds(Accounts User, double balance)
        {
            if (balance <= 0)
            {
                Console.WriteLine("Please enter a positive balance! ");
                return;
            }

            if (balance > User.Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            User.Balance -= balance;
            Console.WriteLine("Successfully withdrawn.New balance: $" + User.Balance + "\t\n");
        }

        public void TransferFunds(Accounts User, double balance)
        {
            if (balance <= 0)
            {
                Console.WriteLine("Please enter transfer fund");
                return;
            }

            if (balance > User.Balance)
            {
                Console.WriteLine("Insufficcient funds \t\n");
                return;
            }

            User.Balance -= balance;
            Console.WriteLine("Succesffully tranferred funds!!. New Balance: " + User.Balance + "\t\n");
        }
    }

}

