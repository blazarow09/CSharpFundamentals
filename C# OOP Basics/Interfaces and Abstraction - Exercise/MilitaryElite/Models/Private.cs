public class Private : Soldier, IPrivate
{
    public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary { get; }

    public override string ToString()
    {
        return string.Format($"{base.ToString()} Salary: {this.Salary:F2}");
    }
}