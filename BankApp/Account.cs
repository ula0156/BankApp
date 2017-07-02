using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    public enum AccountTypes
    {
        Checking,
        Savings,
        CreditCard,
        Loan
    }
    public class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public string AccountName { get; set; }
        [Key] // telling that this is the primary key for your table. The way to uniqly identify a row in the table. AccounNumber would be a primary key for this situation.
        public int AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public AccountTypes TypeOfAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; } // word "virtual" is making a relationship, iCollection - meaning many
        #endregion

        #region Constructor
        public Account()
        {
            lastAccountNumber += 1;
            AccountNumber = lastAccountNumber;
        }

        public Account(string accountName) : this()
        {
            AccountName = accountName;
        }

        public Account(string accountName, string emailAddress) : this(accountName)
        {
            EmailAddress = emailAddress;
        }

        public Account(string accountName, string emailAddress, AccountTypes typeOfAccount) : this(accountName, emailAddress)
        {
            TypeOfAccount = typeOfAccount;
        }

        public Account(string accountName, string emailAddress, AccountTypes typeOfAccount, decimal amount) : this(accountName, emailAddress, typeOfAccount)
        {
            Balance = amount;
        }


        #endregion

        #region Methodes
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Amount is greater than the balance of the account.");
            }
            Balance -= amount;
        }
        #endregion

    }
}
