using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    string result = string.Format(ExceptionMessages.InvalidName, value.ToString(), "5");
                    throw new ArgumentException(result);
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    string result = string.Format(ExceptionMessages.InvalidNumberOfLaps, value.ToString());
                    throw new ArgumentException(result);
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }

            if (!rider.CanParticipate)
            {
                string result = string.Format(ExceptionMessages.RiderNotParticipate, rider.Name);
                throw new ArgumentException(result);
            }
            
            if (this.riders.Any(x => x.Name == rider.Name))
            {
                string result = string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name);
                throw new ArgumentNullException(result);
            }

            this.riders.Add(rider);
        }
    }
}
