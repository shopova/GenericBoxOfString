using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy, ISoldier
    {
        public Spy(string firstName, string secondName, string id, int codeNumber) 
            : base(firstName, secondName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Code Number: {this.CodeNumber}";
        }
    }
}