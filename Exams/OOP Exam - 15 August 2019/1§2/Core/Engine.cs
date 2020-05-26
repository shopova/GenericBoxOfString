using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }

        Controller controller = new Controller();

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;
                    if (input[0] == "AddAstronaut")
                    {
                        result = controller.AddAstronaut(input[1], input[2]);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string[] items = input.Skip(2).ToArray();

                        result = controller.AddPlanet(input[1], items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        result = controller.RetireAstronaut(input[1]);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        result = controller.ExplorePlanet(input[1]);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
