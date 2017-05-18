using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public string AccountName { get; set; }
        public decimal AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public string TypeOfAccount { get; set; }
        #endregion

        #region Constructor
        public Account()
        {
            lastAccountNumber += 1;
            AccountNumber = lastAccountNumber;
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
