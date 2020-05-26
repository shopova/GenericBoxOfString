namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double biologistInitialOxygen = 50;
        public Geodesist(string name)
            : base(name, biologistInitialOxygen)
        {
        }
    }
}
