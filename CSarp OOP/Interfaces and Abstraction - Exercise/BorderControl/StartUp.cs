using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] data = command.Split(' ');
                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    Citizen citizen = new Citizen(name, age, id);
                    all.Add(citizen);
                }
                else
                {
                    string model = data[0];
                    string id = data[1];
                    Robot robot = new Robot(model, id);
                    all.Add(robot);
                }
                command = Console.ReadLine();
            }

            string lastDigits = Console.ReadLine();

            all.Where(x => x.Id.EndsWith(lastDigits)).Select(c => c.Id).ToList().ForEach(Console.WriteLine);
        }
    }
}
