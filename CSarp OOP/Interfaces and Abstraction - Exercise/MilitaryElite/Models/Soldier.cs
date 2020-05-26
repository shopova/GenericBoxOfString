using MilitaryElite.Interfaces;

namespace MilitaryElite
{ 
    public class Soldier : ISoldier
    {
        public Soldier(string firstName, string secondName, string id)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Id = id;
        }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.SecondName} Id: {this.Id} ";
        }
    }
}
