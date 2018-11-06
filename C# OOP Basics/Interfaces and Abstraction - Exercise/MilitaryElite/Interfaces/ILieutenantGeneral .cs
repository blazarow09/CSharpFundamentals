using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        IList<ISoldier> Privates { get; }
    }
}