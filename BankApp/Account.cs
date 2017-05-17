using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    class Account
    { 
        public Account()
        {

        }
    #region Properties
        public string Name { get; set; }
        public decimal Number { get; private set; }
        public string Email { get; set; }
        public decimal Balance { get; private set; }
        public string Type { get; set; }
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
