using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankApp
{
    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }

        public virtual Account Account { get; set; } // tarnsac. class virtually related to account class. Virtual is the special keyword which is establish the relashinship 

    }
}
