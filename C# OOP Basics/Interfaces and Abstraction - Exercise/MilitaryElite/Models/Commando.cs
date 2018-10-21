using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, List<IMissions> missions) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<IMissions> Missions { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.Append("Missions:");
        foreach (var mission in this.Missions)
        {
            sb.AppendLine();
            sb.AppendFormat($"  {mission}");
        }

        return sb.ToString();
    }
}