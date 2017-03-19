using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using SGBank.BLL;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);


        }
        

        [TestCase ("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new FreeAccountDepositRule();
            Account account = new Account();
            account.Type = accountType;
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult,response.Success);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]
        public void FreeAccountWithdrawtRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new FreeAccountWithdrawRule();
            Account account = new Account();
            account.Type = accountType;
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }



    }
}
