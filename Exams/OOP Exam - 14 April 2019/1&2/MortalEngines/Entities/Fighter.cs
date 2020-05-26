using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter, IMachine
    {
        private const double initialHealthPoints = 200;
        private static bool aggresiveMode = true;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
        }

        public bool AggressiveMode { get; private set; } = aggresiveMode;

        public void CalculatePoints()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;

                this.AggressiveMode = false;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;

                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {((this.AggressiveMode == true) ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
