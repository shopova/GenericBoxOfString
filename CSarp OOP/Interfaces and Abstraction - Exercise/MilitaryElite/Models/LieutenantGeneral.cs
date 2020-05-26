using MilitaryElite.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral, ISoldier, IPrivate
    {
        private const string offset = "  ";

        public LieutenantGeneral(string firstName, string secondName, string id, decimal salary) 
            : base(firstName, secondName, id, salary)
        {
            Privates = new HashSet<Private>();
        }

        public ICollection<Private> Privates { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString()).AppendLine("Privates:");

            foreach (var priv in Privates)
            {
                sb.AppendLine($"{offset}{priv.ToString()}");
            }

            return sb.ToString();
        }
    }
}
