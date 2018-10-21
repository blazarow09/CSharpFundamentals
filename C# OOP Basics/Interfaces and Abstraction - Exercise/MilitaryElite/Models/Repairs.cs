public class Repairs : IRepairs
{
    public Repairs(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    public string PartName { get; }

    public int HoursWorked { get; }

    public override string ToString()
    {
        return string.Format($"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}");
    }
}