using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<string, BankAccount>();

        var tokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        while (tokens[0] != "End")
        {
            var command = tokens[0];
            var accName = tokens[1];

            switch (command)
            {
                case "Create":
                    CreateAccount(accName, accounts, tokens);
                    break;
                case "Deposit":
                    DepositToAccount(accName, accounts, tokens);
                    break;
                case "Withdraw":
                    WithdrawFormAccount(accName, accounts, tokens);
                    break;
                case "Print":
                    PrintAccount(accName, accounts, tokens);
                    break;
            }

            tokens = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

    }

    private static void CreateAccount(string accName, Dictionary<string, BankAccount> accounts, string[] tokens)
    {
        if (IsNameValid(accName))
        {
            if (accounts.ContainsKey(accName))
            {
                Console.WriteLine("Account already exist!");
            }
            else
            {
                var acc = new BankAccount();
                acc.Name = accName;
                accounts.Add(accName, acc);
            }
        }
    }

    private static void PrintAccount(string accName, Dictionary<string, BankAccount> accounts, string[] tokens)
    {
        Console.WriteLine(accounts[accName].ToString());
    }

    private static void WithdrawFormAccount(string accName, Dictionary<string, BankAccount> accounts, string[] tokens)
    {
        if (IsNameValid(accName) && IsAccountValid(accName, accounts))
        {
            var amount = decimal.Parse(tokens[2]);
            accounts[accName].Withdraw(amount);
        }
    }

    private static void DepositToAccount(string accName, Dictionary<string, BankAccount> accounts, string[] tokens)
    {
        if (IsNameValid(accName) && IsAccountValid(accName, accounts))
        {
            var amount = decimal.Parse(tokens[2]);
            accounts[accName].Deposit(amount);
        }
    }

    private static bool IsAccountValid(string accName, Dictionary<string, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accName))
        {
            return true;
        }

        Console.WriteLine("Account does not exist!");
        return false;
    }

    private static bool IsNameValid(string accName)
    {
        var pattern = @"^[A-Z{1}][a-z]+$";

        if (Regex.IsMatch(accName, pattern))
        {
            return true;
        }

        Console.WriteLine("The name is not valid!");
        return false; 
    }
}
