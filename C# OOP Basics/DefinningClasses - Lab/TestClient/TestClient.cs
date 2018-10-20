using System;
using System.Collections.Generic;

internal class TestClient
{
    private static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();

        var line = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        while (line[0] != "End")
        {
            var command = line[0];
            var accId = int.Parse(line[1]);

            switch (command)
            {
                case "Create":
                    CreateAccount(line, accounts, accId);
                    break;

                case "Deposit":
                    DepositToAccount(line, accounts, accId);
                    break;

                case "Withdraw":
                    WithdrawFromAccount(line, accounts, accId);
                    break;

                case "Print":
                    PrintAccount(line, accounts, accId);
                    break;

                default:
                    break;
            }

            line = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }

    private static void PrintAccount(string[] line, Dictionary<int, BankAccount> accounts, int accId)
    {
        Console.WriteLine(accounts[accId].ToString());
    }

    private static void WithdrawFromAccount(string[] line, Dictionary<int, BankAccount> accounts, int accId)
    {
        if (IsAccountValid(accId, accounts))
        {
            var amount = int.Parse(line[2]);
            accounts[accId].WithDraw(amount);
        }
    }

    private static void DepositToAccount(string[] line, Dictionary<int, BankAccount> accounts, int accId)
    {
        if (IsAccountValid(accId, accounts))
        {
            var amount = int.Parse(line[2]);
            accounts[accId].Deposit(amount);
        }
    }

    private static void CreateAccount(string[] line, Dictionary<int, BankAccount> accounts, int accId)
    {
        if (accounts.ContainsKey(accId))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = accId;
            accounts.Add(accId, acc);
        }
    }

    private static bool IsAccountValid(int accId, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accId))
        {
            return true;
        }

        Console.WriteLine("Account does not exist");
        return false;
    }
}