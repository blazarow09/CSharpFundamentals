using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps, List<IRepairs> repairs) : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<IRepairs> Repairs { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.Append("Repairs:");
        foreach (var repair in this.Repairs)
        {
            sb.AppendLine();
            sb.AppendFormat("  {0}", repair);
        }

        return sb.ToString();
    }
}