using MXGP.Utilities.Messages;
using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double powerCubicCentimiters = 450;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, powerCubicCentimiters)
        {
        }

        protected override int MinHorsePower => 70;

        protected override int MaxHorsePower => 100;
    }
}
