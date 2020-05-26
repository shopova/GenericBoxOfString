using MilitaryElite.Interfaces;
using System.Collections.Generic;

namespace MilitaryElite
{
    class Engineer : Soldier, ISoldier, ISpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string secondName, string id) 
            : base(firstName, secondName, id)
        {
            this.Repairs = new HashSet<Repair>();
        }

        public ICollection<Repair> Repairs { get; }
    }
}
