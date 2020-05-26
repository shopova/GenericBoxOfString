namespace Animals
{
    public class Tomcat : Cat, IProduceSound
    {
        public Tomcat(string name, int age)
            : base(name, age, "male")
        {
        }
        
        public string ProduceSound()
        {
            return "MEOW";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
