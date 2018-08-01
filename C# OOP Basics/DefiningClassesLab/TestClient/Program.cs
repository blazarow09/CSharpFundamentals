using System;
using System.Collections.Generic;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Dictionary<int, BankAccount>();

            string line;

            while ((line = Console.ReadLine()) != "End") 
            {
                var tokens = line.Split(" ");

                var command = tokens[0];
                var accountId = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Create":
                        if (account.ContainsKey(accountId))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            account.Add(accountId, new BankAccount { ID = accountId });
                        }
                        break;
                    case "Deposit":
                        if (IsAccountValid(accountId, account))
                        {
                            var deposit = int.Parse(tokens[2]);
                            account[accountId].Deposit(deposit);
                        }
                        break;
                    case "Withdraw":
                        if (IsAccountValid(accountId, account))
                        {
                            var withdraw = int.Parse(tokens[2]);
                            account[accountId].Withdraw(withdraw);
                        }
                        break;
                    case "Print":
                        if (IsAccountValid(accountId, account))
                        {
                            Console.WriteLine(account[accountId].ToString());
                        }
                        break;
                }

            }

            
        }

        static bool IsAccountValid (int accountId, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(accountId))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Account does not exist");
                return false;
            }
        }
    }
}
