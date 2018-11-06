using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IList<ISoldier> privates) : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public IList<ISoldier> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var @private in this.Privates)
            {
                sb.AppendLine($"  {@private.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}