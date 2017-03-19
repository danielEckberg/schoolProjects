using SGBank.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Responses;

namespace SGBank.UI.WorkFlows
{
    public class WithdrawWorkflow
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
                Console.Write("Enter a withdrawal amount: ");
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
            
            
            
            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:C}");
                Console.WriteLine($"Amount withdrawn: {response.Amount:C}");
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
