using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            string driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine($"{ferrari.Model}/{ferrari.Stop()}/{ferrari.Accelerate()}/{ferrari.Driver}");
        }
    }
}
