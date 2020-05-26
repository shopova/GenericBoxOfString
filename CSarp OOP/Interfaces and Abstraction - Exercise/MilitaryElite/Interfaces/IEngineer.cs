using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer
    {
        ICollection<Repair> Repairs { get; }
    }
}
