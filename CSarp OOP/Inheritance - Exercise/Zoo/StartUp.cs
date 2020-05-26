using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal = new Mammal("Gosho");

            Console.WriteLine(animal.Name);
        }
    }
}
