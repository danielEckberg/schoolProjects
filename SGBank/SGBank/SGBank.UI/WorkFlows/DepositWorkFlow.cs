using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.WorkFlows
{
    public class DepositWorkFlow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.Clear();
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            decimal amount;
            while (true)
            {
                Console.Write("Enter a deposit amount: ");
                string input = Console.ReadLine();

                bool result = decimal.TryParse(input, out amount);
                if (result)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid amount.");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:C}");
                Console.WriteLine($"Amount Deposited: {response.Amount:C}");
                Console.WriteLine($"New balance: {response.Account.Balance:C}");
            }
            else
            {
                Console.Write("An error occured: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
