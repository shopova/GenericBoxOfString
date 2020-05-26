using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                try
                {
                    string[] dataDog = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = dataDog[0];
                    int age;
                    if (!int.TryParse(dataDog[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = dataDog[2];


                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine("Dog");
                            Console.WriteLine(dog.GetResult());
                            break;
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine("Cat");
                            Console.WriteLine(cat.GetResult());
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine("Frog");
                            Console.WriteLine(frog.GetResult());
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine("Kitten");
                            Console.WriteLine(kitten.GetResult());
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine("Tomcat");
                            Console.WriteLine(tomcat.GetResult());
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                input = Console.ReadLine();
            }
        }
    }
}