public class BankAccount
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
        this.Balance += amount;
    }

    public void Withdraw (decimal amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.ID}, balance {this.Balance}";
    }
}
