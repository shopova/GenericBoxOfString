namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        private const string name = "Ferrari";
        private const string model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Name = name;
            this.Model = model;
            this.Driver = driver;
        }
        public string Driver { get; set; }

        public string Name { get; }

        public string Model { get; }
        public string Stop()
        {
            return "Brakes!";
        }

        public string Accelerate()
        {
            return "Gas!";
        }
    }
}
