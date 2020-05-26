using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(string firstName, string secondName, string id, decimal salary) 
            : base(firstName, secondName, id)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary.ToString()}";
        }
    }
}
