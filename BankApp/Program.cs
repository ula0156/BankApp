using System;

namespace bankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new instance of the account class 
            // and set property for it;
            var account = new Account();
            account.AccountName = "My checking";
            account.EmailAddress = "test@test.com";
            account.TypeOfAccount = "Checking";

            account.Deposit(200);
            Console.WriteLine($"AccountNumber : {account.AccountNumber}, Balance: {account.Balance}, EmailAddres: {account.EmailAddress}, TypeOfAccount: {account.TypeOfAccount}");
        }
    }
}
