using System;
namespace ConsoleApp21
{

    public interface IBillable
    {
        int CostForDay(int hoursWorked);
    }

    public abstract class Employee : IBillable
    {
        public string Id;
        public string Name;

        protected Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract int CostForDay(int hoursWorked);
    }

    public class FullTimeEmployee : Employee
    {
        private const int HourlyWage = 1250;
        private const double OvertimeRate = 1.25;
        private const int RegularHours = 8;

        public FullTimeEmployee(string id, string name)
            : base(id, name)
        {
        }

        public override int CostForDay(int hoursWorked)
        {
            int regularHours = Math.Min(hoursWorked, RegularHours);
            int overtimeHours = Math.Max(0, hoursWorked - RegularHours);

            double cost =
                regularHours * HourlyWage +
                overtimeHours * HourlyWage * OvertimeRate;

            return (int)cost;
        }
    }
    public class ContractEmployee : Employee
    {
        private const int HourlyWage = 1000;

        public ContractEmployee(string id, string name)
            : base(id, name)
        {
        }

        public override int CostForDay(int hoursWorked)
        {
            return hoursWorked * HourlyWage;
        }
    }

    class Program
    {
        static void Main()
        {
            List<IBillable> employees = new List<IBillable>
            {
                new FullTimeEmployee("E001", "山田太郎"),
                new ContractEmployee("C001", "佐藤花子")
            };

            int hoursWorked = 9;

            foreach (var item in employees)
            {
                int wage = item.CostForDay(hoursWorked);
                Console.WriteLine($"日給: {wage}円");
            }
        }
    }
}
        

