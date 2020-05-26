using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defencePoints;
        private List<string> targets;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.NullMachine));
                }
                this.name = value;
            }

        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.NullPilot));
                }
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get => this.attackPoints;
            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get => this.defencePoints;
            protected set
            {
                this.defencePoints = value;
            }
        }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.AttackNullTarget));
            }
            
            if (target.DefensePoints - this.attackPoints <= 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints = this.attackPoints - target.DefensePoints;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");
            sb.Append($" *Targets: ");

            if (this.Targets.Count > 0)
            {
                foreach (var target in targets)
                {
                    sb.Append($"{target}");
                }
            }
            else
            {
                sb.Append("None");
            }

            sb.AppendLine();
            return sb.ToString().TrimEnd();
        }
    }
}
