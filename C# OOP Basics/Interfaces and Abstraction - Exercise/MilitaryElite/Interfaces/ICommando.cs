using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando
    {
        IList<IMission> Missions { get; }
    }
}