using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        public static string Name { get; set; }

        // create a method for this class
        public static Account CreateAccount(string accountName, string emailAddress, AccountTypes typeOfAccount, decimal amount)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                TypeOfAccount = typeOfAccount
            };

            if (amount > 0)
            {
                account.Deposit(amount);
            }
            accounts.Add(account);
            return account;
        }

        public static List<Account> GetAllAccounts()
        {
            return accounts;
        } 
    }
}
