namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);
            if (this.pilots.Contains(pilot))
            {
                return $"Pilot {name} is hired already";
            }

            this.pilots.Add(pilot);
            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            Tank tank = new Tank(name, attackPoints, defensePoints);

            if (this.machines.Contains(tank))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            tank.CalculatePoints();
            this.machines.Add(tank);

            string result = string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints, tank.DefenseMode == true ? "ON" : "OFF");

            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            Fighter fighter = new Fighter(name, attackPoints, defensePoints);

            if (this.machines.Contains(fighter))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            fighter.CalculatePoints();

            this.machines.Add(fighter);

            string result = string.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");

            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, pilot.Name);
            }

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, machine.Name);
            }

            if (machine.Pilot != null)
            {

                return string.Format(OutputMessages.MachineHasPilotAlready, machine.Name);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;


            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachine.Name);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachine.Name);
            }

            if (attackingMachine.HealthPoints < 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine.Name);
            }

            if (defendingMachine.HealthPoints < 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine.Name);
            }
            
            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            if(pilot != null)
            {
                return pilot.Report();
            }

            return null;
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == machineName);

            if (machine != null)
            {
                return machine.ToString();
            }

            return null;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter fighter = (Fighter)machines.FirstOrDefault(x => x.Name == fighterName);

            if (fighter != null)
            {
                fighter.ToggleAggressiveMode();

                return string.Format(OutputMessages.FighterOperationSuccessful, fighter.Name);
            }

            return string.Format(OutputMessages.MachineNotFound, fighter.Name);

        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)machines.FirstOrDefault(x => x.Name == tankName);

            if (tank != null)
            {
                tank.ToggleDefenseMode();

                return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}