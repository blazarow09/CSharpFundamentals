using System;

public class BankAccount
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amoumt)
    {
        if (Balance >= amoumt)
        {
            this.Balance -= amoumt;
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name} have {this.Balance:f2}$ left.";
    }
}