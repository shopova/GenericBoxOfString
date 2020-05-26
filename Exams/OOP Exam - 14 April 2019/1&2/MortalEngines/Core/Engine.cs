using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IMachinesManager controller;

        public Engine(IReader reader, IWriter writer, IMachinesManager managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = managerController;
        }

        public void Run()
        {
            string[] commands = this.reader.ReadLine().Split().ToArray();

            while (commands[0] != "Quit")
            {
                try
                {
                    string result = string.Empty;

                    switch (commands[0])
                    {
                        case "HirePilot":
                            result = controller.HirePilot(commands[1]);
                            break;
                        case "PilotReport":
                            result = controller.PilotReport(commands[1]);
                            break;
                        case "ManufactureTank":
                            result = controller.ManufactureTank(commands[1], int.Parse(commands[2]), int.Parse(commands[3]));
                            break;
                        case "ManufactureFighter":
                            result = controller.ManufactureFighter(commands[1], int.Parse(commands[2]), int.Parse(commands[3]));
                            break;
                        case "MachineReport":
                            result = controller.MachineReport(commands[1]);
                            break;
                        case "AggressiveMode":
                            result = controller.ToggleFighterAggressiveMode(commands[1]);
                            break;
                        case "DefenseMode":
                            result = controller.ToggleTankDefenseMode(commands[1]);
                            break;
                        case "Engage":
                            result = controller.EngageMachine(commands[1], commands[2]);
                            break;
                        case "Attack":
                            result = controller.AttackMachines(commands[1], commands[2]);
                            break;

                    }

                    writer.WriteLine(result);
                    commands = reader.ReadLine().Split().ToArray();
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
