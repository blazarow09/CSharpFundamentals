class BankAccount
{
    private int Id;

    public int ID
    {
        get { return Id; }
        set { Id = value; }
    }

    private decimal  balance;

    public decimal  Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw (decimal amount)
    {
        if (Balance < amount)
        {
            System.Console.WriteLine("Insufficient balance");
        }
        else
        {
        Balance -= amount;
        }
    }

    public override string ToString()
    {
        return $"Account ID{this.ID}, balance {this.Balance:f2}";
    }
}

