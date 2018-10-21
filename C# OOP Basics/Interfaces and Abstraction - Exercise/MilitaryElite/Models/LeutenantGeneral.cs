using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<ISoldier> privates) : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<ISoldier> Privates { get; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.Append("Privates:");
        foreach (var privateInCommand in this.Privates)
        {
            sb.AppendLine();
            sb.AppendFormat("  {0}", privateInCommand);
        }

        return sb.ToString();
    }
}