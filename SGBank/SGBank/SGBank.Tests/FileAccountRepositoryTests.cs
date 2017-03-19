using System;
using System.Collections.Generic;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Data;
using SGBank.Models;
using SGBank.Models.Responses;
using System.IO;
using NUnit.Framework.Internal;

namespace SGBank.Tests
{
    [TestFixture]
    public class FileAccountRepositoryTests
    {
        private const string _FilePath =
            @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\SGBank\Accounts.txt";
        //private const string _originalData = @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\SGBank\AccountsTestSeed.txt";

        //[SetUp]
        //public void Setup()
        //{
        //    if (File.Exists(_FilePath))
        //    {
        //        File.Delete(_FilePath);
        //    }

        //    File.Copy(_originalData, _FilePath);

        //}

        [Test]
        public void CanReadDataFromFile()
        {
            FileAccountRepository repo = new FileAccountRepository(_FilePath);

            List<Account> accounts = repo.List();

            Assert.AreEqual(3, accounts.Count);

            Account check = accounts[1];

            Assert.AreEqual("22222", check.AccountNumber);
            Assert.AreEqual("Basic Customer", check.Name);
            Assert.AreEqual(500, check.Balance);
            Assert.AreEqual(AccountType.Basic, check.Type);
        }

        [Test]
        public void CanLoadFileAccountTestData(string AccountNumber)
        {
            FileAccountRepository repo = new FileAccountRepository(_FilePath);
            List<Account> accounts = repo.List();
            AccountNumber = "22222";
            Account account = repo.LoadAccount(AccountNumber);
            

            Assert.AreEqual("22222",account.AccountNumber);
            
        }
    }
}
