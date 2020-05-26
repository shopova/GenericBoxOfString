using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();

            int numOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPeople; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthDate = data[3];

                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    citizens.Add(citizen);
                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    Rebel rebel = new Rebel(name, age, group);
                    rebels.Add(rebel);
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string name = command;
                Citizen citizen = citizens.FirstOrDefault(x => x.Name == name);
                Rebel rebel = rebels.FirstOrDefault(x => x.Name == name);

                if (citizen != null)
                {
                    citizen.BuyFood();
                }
                else if (rebel != null)
                {
                    
                    rebel.BuyFood();
                }
                command = Console.ReadLine();
            }

            int foodSum = 0;

            foreach (var citizen in citizens)
            {
                foodSum += citizen.Food;
            }

            foreach (var rebel in rebels)
            {
                foodSum += rebel.Food;
            }

            Console.WriteLine(foodSum);
        }
    }
}
