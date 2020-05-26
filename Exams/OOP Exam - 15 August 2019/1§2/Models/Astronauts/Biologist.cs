namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double biologistInitialOxygen = 70;
        public Biologist(string name) 
            : base(name, biologistInitialOxygen)
        {
        }

        public override void Breath()
        {
            this.oxygenDrop = 5;
            base.Breath();
        }
    }
}
