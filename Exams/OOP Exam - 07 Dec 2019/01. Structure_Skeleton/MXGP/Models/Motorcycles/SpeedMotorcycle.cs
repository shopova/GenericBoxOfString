using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double speedCubicCentimiters = 125;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, speedCubicCentimiters)
        {
        }

        protected override int MinHorsePower => 50;

        protected override int MaxHorsePower => 69;
    }
}
