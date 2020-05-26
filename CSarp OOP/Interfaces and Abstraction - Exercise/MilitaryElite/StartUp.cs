using System;
using System.Collections.Generic;
using static MilitaryElite.Interfaces.ISpecialisedSoldier;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            var privates = new Dictionary<string, Private>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var soldierType = cmdArgs[0];
                string id;
                string firstName;
                string lastName;
                decimal salary;
                Corps corps;

                switch (soldierType)
                {
                    case "Private":
                        id = cmdArgs[1];
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = decimal.Parse(cmdArgs[4]);

                        var privateSoldier = new Private(firstName, lastName, id, salary);
                        privates.Add(id, privateSoldier);
                        Console.WriteLine(privateSoldier);
                        break;
                    case "LieutenantGeneral":
                        id = cmdArgs[1];
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = decimal.Parse(cmdArgs[4]);
                        var leutenantGeneral = new LieutenantGeneral(firstName, lastName, id, salary);

                        if (cmdArgs.Length >= 5)
                        {
                            for (var i = 5; i < cmdArgs.Length; i++)
                            {
                                string privateId = cmdArgs[i];
                                privateSoldier = privates[privateId];

                                leutenantGeneral.Privates.Add(privateSoldier);
                            }
                        }
                        Console.WriteLine(leutenantGeneral);
                        break;
                    case "Engineer":
                        id = cmdArgs[1];
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = decimal.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            var engineer = new Engineer(firstName, lastName, id);

                            if (cmdArgs.Length >= 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    var repairPartName = cmdArgs[i];
                                    var repairHours = int.Parse(cmdArgs[i + 1]);

                                    var repair = new Repair(repairPartName, repairHours);
                                    engineer.Repairs.Add(repair);
                                }
                            }
                            Console.WriteLine(engineer);
                        }
                        break;
                    case "Commando":
                        id = cmdArgs[1];
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        salary = decimal.Parse(cmdArgs[4]);

                        if (Enum.TryParse(cmdArgs[5], out corps))
                        {
                            Commando commando = new Commando(firstName, lastName, id, salary, corps);

                            if (cmdArgs.Length > 6)
                            {
                                for (var i = 6; i < cmdArgs.Length; i += 2)
                                {
                                    if (Enum.TryParse(cmdArgs[i + 1], out MissionState missionState))
                                    {
                                        var missionName = cmdArgs[i];
                                        var mission = new Mission(missionName, missionState);
                                        commando.Missions.Add(mission);
                                    }
                                }
                                Console.WriteLine(commando.ToString());
                            }
                        }
                        break;
                    case "Spy":
                        id = cmdArgs[1];
                        firstName = cmdArgs[2];
                        lastName = cmdArgs[3];
                        var codeNumber = int.Parse(cmdArgs[4]);

                        var spy = new Spy(id, firstName, lastName, codeNumber);
                        Console.WriteLine(spy);
                        break;
                    default:
                        throw new ArgumentException("Invalid Type of Soldier!");
                }
            }
        }
    }
}