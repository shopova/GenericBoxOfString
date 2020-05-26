using System;
using System.Linq;
using MXGP.IO.Contracts;

namespace MXGP.Core.Contracts
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private ChampionshipController championshipController;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputArgs = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                try
                {
                    if (inputArgs[0] == "End")
                    {
                        break;
                    }
                    else if (inputArgs[0] == "CreateRider")
                    {
                        string name = inputArgs[1];
                        writer.WriteLine(championshipController.CreateRider(name));
                    }
                    else if (inputArgs[0] == "CreateMotorcycle")
                    {
                        string name = inputArgs[1];
                        string model = inputArgs[2];
                        int horsePower = int.Parse(inputArgs[3]);
                        writer.WriteLine(championshipController.CreateMotorcycle(name, model, horsePower));
                    }
                    else if (inputArgs[0] == "AddMotorcycleToRider")
                    {
                        string name = inputArgs[1];
                        string motorcycleModel = inputArgs[2];
                        writer.WriteLine(championshipController.AddMotorcycleToRider(name, motorcycleModel));
                    }
                    else if (inputArgs[0] == "AddRiderToRace")
                    {
                        string name = inputArgs[1];
                        string race = inputArgs[2];
                        writer.WriteLine(championshipController.AddRiderToRace(name, race));
                    }
                    else if (inputArgs[0] == "CreateRace")
                    {
                        string name = inputArgs[1];
                        int laps = int.Parse(inputArgs[2]);
                        writer.WriteLine(championshipController.CreateRace(name, laps));
                    }
                    else if (inputArgs[0] == "StartRace")
                    {
                        string name = inputArgs[1];
                        writer.WriteLine(championshipController.StartRace(name));
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
