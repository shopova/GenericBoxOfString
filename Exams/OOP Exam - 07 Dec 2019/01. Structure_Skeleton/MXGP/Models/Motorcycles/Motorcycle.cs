using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        protected int horsePower;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    string result = string.Format(ExceptionMessages.InvalidModel, value.ToString(), "4");
                    throw new ArgumentException(result);
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters{ get; protected set; }

        protected abstract int MinHorsePower { get; }

        protected abstract int MaxHorsePower { get; }

        public double CalculateRacePoints(int laps)
        {
            double result = this.CubicCentimeters / this.horsePower * laps;
            return result;
        }
    }
}
