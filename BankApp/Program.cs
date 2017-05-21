using System;

namespace bankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Welcome to my Bank********");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2: Deposit");
            Console.WriteLine("3: Withdraw");
            Console.WriteLine("4: Print all accounts");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    return;
                case "1":
                    Console.Write("Account name: ");
                    var accountName = Console.ReadLine();
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    Console.WriteLine("Type of account: ");
                    var accountTypes = Enum.GetNames(typeof(AccountTypes));
                    for (int i = 0; i < accountTypes.Length; i++)
                    {
                        Console.WriteLine($"{i}. {accountTypes[i]}");
                    }
                    Console.Write("Pick an account type: ");
                    var accountType = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Amount: ");
                    var amount = Convert.ToDecimal(Console.ReadLine());
                    var account = new Account
                    {
                        AccountName = accountName,
                        EmailAddress = emailAddress,
                        TypeOfAccount = (AccountTypes)accountType
                    };
                    account.Deposit(amount);
                    Console.WriteLine($"AN: {account.AccountName}, Balance: {account.Balance}");
                    break;
                case "2":
                case "3":
                case "4":
                default:
                    break;
            }
        }
    }
}
