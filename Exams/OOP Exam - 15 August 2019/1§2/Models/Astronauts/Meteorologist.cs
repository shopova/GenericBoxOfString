namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double biologistInitialOxygen = 90;
        public Meteorologist(string name)
            : base(name, biologistInitialOxygen)
        {
        }
    }
}
