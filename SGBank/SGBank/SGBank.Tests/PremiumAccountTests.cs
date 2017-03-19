using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("54321", "Premium Account", 1500, AccountType.Premium, -1000, 1500, false)]
        [TestCase("54321", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("54321", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("54321", "Premium Account", 10, AccountType.Premium, -50, -40, true)]
        [TestCase("54321", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("54321", "Premium Account", -100, AccountType.Premium, -500, -610, true)]
        public void PremiumAccountWithdrawtRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRules();
            Account account = new Account();
            account.Type = accountType;
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success == true)
                Assert.AreEqual(newBalance, actual: account.Balance);
        }
    }
}
