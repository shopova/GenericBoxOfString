using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        public double oxygenDrop = 10; // Should bi like that?

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.CanBreath = true;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidAstronautName, value));
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidOxygen, value));
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get; }

        public virtual void Breath()
        {
            if (this.Oxygen - oxygenDrop < 0)
            {
                CanBreath = false;
                throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidOxygen, ((this.Oxygen - oxygenDrop))));
            }
            else
            {
                CanBreath = true;
                this.Oxygen -= oxygenDrop;
            }
        }
    }
}
