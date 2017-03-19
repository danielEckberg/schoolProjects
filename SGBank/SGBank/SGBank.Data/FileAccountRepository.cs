using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;


namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public const string FilePath =
          @"C:\Users\dr3ek\Documents\bootcamp\daniel.eckberg.self.work\Labs\SGBank\Accounts.txt";

        private string _filePath;

        public FileAccountRepository(string FilePath)
        {
            _filePath = FilePath;
        }


        public List<Account> List()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account account = new Account();

                    string[] columns = line.Split(',');

                    account.AccountNumber = columns[0];
                    account.Name = columns[1];
                    account.Balance = decimal.Parse(columns[2]);
                    switch (columns[3])
                    {
                        case "F":
                            account.Type = AccountType.Free;
                            break;
                        case "B":
                            account.Type = AccountType.Basic;
                            break;
                        case "P":
                            account.Type = AccountType.Premium;
                            break;
                    }

                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public int index;
        public Account LoadAccount(string AccountNumber)
        {
            foreach (var account in List())
            {
                if (account.AccountNumber == AccountNumber)
                {
                    return account;
                }
                index++;
            }
            return null;

        }

        public void SaveAccount(Account account)
        {
            var accounts = List();

            accounts[index] = account;

            CreateAccountsFile(accounts);
        }

        private string CreateCsvForAccount(Account account)
        {
            
            return string.Format("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance.ToString(),
                account.Type.ToString().First());
        }

        private void CreateAccountsFile(List<Account> accounts)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var acccount in accounts)
                {
                    sr.WriteLine(CreateCsvForAccount(acccount));
                }
            }
        }
    }
}
