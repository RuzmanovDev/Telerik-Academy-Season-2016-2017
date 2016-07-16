namespace StudentsAndWorkers.Models
{
    public class Worker : Human
    {
        public Worker(string firstname, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstname, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        public decimal MoneyPerHour(decimal weeklySalary, int workingDays)
        {
            decimal result = this.WeekSalary / (decimal)workingDays;
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + $"Weekly salary: {this.WeekSalary} Working hours per day: {this.WorkHoursPerDay}";
        }
    }
}
