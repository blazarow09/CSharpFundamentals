using System;

namespace Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        private double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            return $"First Name: {base.FirstName}\n" +
                $"Last Name: {base.LastName}\n" +
                $"Week Salary: {this.WeekSalary:f2}\n" +
                $"Hours per day: {this.WorkHoursPerDay:f2}\n" +
                $"Salary per hour: {CalculateSalaryPerHour():f2}";
        }
    }
}