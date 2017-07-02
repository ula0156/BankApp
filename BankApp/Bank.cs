﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    static class Bank
    {
        private static BankModel db = new BankModel(); // because class is static all the members/methods of this class must be static
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
            db.Accounts.Add(account); // database of the table account add this account to this database
            db.SaveChanges(); // save changes in the database!
            return account;
        }

        public static List<Account> GetAllAccounts()
        {
            return db.Accounts.ToList(); // read database from a table -> convert everything to a list
        }

        public static List<Transaction> GetAllTransacationForAccount(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).ToList();
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            //LINQ, inside is the landa expression
            return db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException("Account Number is not valid.");
            }
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Branch deposit",
                TransactionType = TransactionType.Credit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException("Account is not valid");
            }
            account.Withdraw(amount);
            var transacton = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Branch withdraw",
                TransactionType = TransactionType.Credit,
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transacton);
            db.SaveChanges();

        }

    }
}
