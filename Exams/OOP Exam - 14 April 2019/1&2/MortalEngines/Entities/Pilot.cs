using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }


        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.NullPilotName));
                }
                this.name = value;
            }

        }

        public IList<IMachine> Machines => this.machines;

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.AddNullMachine));
            }
            else
            {
                this.machines.Add(machine);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var machine in Machines)
            {
                machine.ToString();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
