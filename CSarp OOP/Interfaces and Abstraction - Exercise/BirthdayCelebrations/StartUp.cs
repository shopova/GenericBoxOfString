using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandParams = command.Split();
                string type = commandParams[0];

                switch (type)
                {
                    case "Citizen":
                        string CitizenName = commandParams[1];
                        int CitizenAge = int.Parse(commandParams[2]);
                        string CitizenId = commandParams[3];
                        string CitizenBirthDate = commandParams[4];

                        Citizen citizen = new Citizen(CitizenName, CitizenAge, CitizenId, CitizenBirthDate);
                        all.Add(citizen);
                        break;
                    case "Pet":
                        string PetName = commandParams[1];
                        string PetBirthDate = commandParams[2];

                        Pet pet = new Pet(PetName, PetBirthDate);
                        all.Add(pet);
                        break;
                }

                command = Console.ReadLine();
            }

            string specificYear = Console.ReadLine();

            all.Where(x => x.BirthDate.EndsWith(specificYear)).Select(x => x.BirthDate).ToList().ForEach(Console.WriteLine);
        }
    }
}
