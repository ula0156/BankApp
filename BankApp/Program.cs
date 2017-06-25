using System;

namespace bankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Welcome to my Bank********");
            while (true)
            {
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

                        // Because bank class is the static class, we don't use word new for constructor function
                        var account = Bank.CreateAccount(accountName, emailAddress, (AccountTypes)accountType, amount);
                        Console.WriteLine($"AN: {account.AccountNumber}, Balance: {account.Balance:C}");
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Select the account number to do a deposit: ");
                        var accountNum = Convert.ToInt32(Console.ReadLine());
                        account = Bank.GetAccountByAccountNumber(accountNum);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid account number. Please try again.");

                        }
                        else
                        {
                            Console.Write("Amount to deposit: ");
                            amount = Convert.ToDecimal(Console.ReadLine());
                            Bank.Deposit(account, amount);
                            Console.WriteLine("Deposit completed successfully!");
                        }
                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("Select the account number to do a withdraw: ");
                        accountNum = Convert.ToInt32(Console.ReadLine());
                        account = Bank.GetAccountByAccountNumber(accountNum);
                        if (account == null)
                        {
                            Console.WriteLine("Invalid account number. Please try again.");

                        }
                        else
                        {
                            try
                            {
                                Console.Write("Amount to withdraw: ");
                                amount = Convert.ToDecimal(Console.ReadLine());
                                Bank.Withdraw(account, amount);
                                Console.WriteLine("Withdraw completed successfully!");
                            }
                            catch (ArgumentOutOfRangeException ax)
                            {
                                Console.WriteLine($"Ooops! Withdraw failed. Here is why - {ax.Message}");
                            }
                        }
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var accnt in accounts)
            {
                Console.WriteLine($"AN: {accnt.AccountNumber}, Balance: {accnt.Balance:C}");
            }
        }
    }
}
