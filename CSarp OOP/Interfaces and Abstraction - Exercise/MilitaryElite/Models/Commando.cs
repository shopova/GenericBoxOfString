using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;
using static MilitaryElite.Interfaces.ISpecialisedSoldier;

namespace MilitaryElite
{
    class Commando : ISoldier, IPrivate, ICommando
    {
        public Commando(string firstName, string lastName, string id, decimal salary, Corps corps)
        {
            Id = id;
            FirstName = firstName;
            SecondName = lastName;
            Salary = salary;
            Corps = corps;
            Missions = new HashSet<Mission>();
        }

        public string Id { get; }

        public string FirstName { get; }

        public string SecondName { get; }

        public decimal Salary { get; }

        public Corps Corps { get; }

        public ICollection<Mission> Missions { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
