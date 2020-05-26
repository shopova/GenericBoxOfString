using System;

namespace Person
{
    public class StartUp
    {
        static void Main()
        {

            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Person person;
                if (age <= 15)
                {
                    person = new Child(name, age);
                }
                else
                {
                    person = new Person(name, age);
                }
                Console.WriteLine(person);
            }
            catch (Exception)
            {
            }
        }
    }
}
