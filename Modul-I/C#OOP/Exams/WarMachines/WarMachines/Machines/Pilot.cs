namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    class Pilot : IPilot
    {
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get; set;
        }

        public IList<IMachine> Machines
        {
            get { return new List<IMachine>(machines); }
            set { this.machines = value; }
        }
        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            //(pilot name) – (number of machines/”no”) (“machine”/”machines”)
            int machinesCount = this.machines.Count;

            string machineRepot = machinesCount > 0 ? machinesCount.ToString() : "no";
            string moreThanOne = machinesCount == 1 ? "machine" : "machines";

            string pilotInfo = string.Format("{0} - {1} {2}", this.Name, machineRepot, moreThanOne);
            result.AppendLine(pilotInfo);

            var sortedMachines = this.machines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);

            if (machinesCount > 0)
            {
                foreach (var machine in sortedMachines)
                {
                    result.AppendLine(machine.ToString());
                }
            }

            return result.ToString().Trim();
        }
    }
}
