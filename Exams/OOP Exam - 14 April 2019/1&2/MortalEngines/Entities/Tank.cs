using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank, IMachine
    {
        private const double initialHealthPoints = 100;
        private static bool defenseMode = true;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
        }

        public bool DefenseMode { get; private set; } = defenseMode;

        public void CalculatePoints()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;

                this.DefenseMode = false;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;

                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine($" * Defense: {((this.DefenseMode == true) ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
