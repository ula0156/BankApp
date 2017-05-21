using System;
using System.Collections.Generic;
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
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public string AccountName { get; set; }
        public decimal AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public AccountTypes TypeOfAccount { get; set; }
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
            Balance -= amount;
        }
        #endregion

    }
}
