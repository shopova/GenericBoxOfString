using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    interface ICommando
    {
        ICollection<Mission> Missions { get; }
    }
}
