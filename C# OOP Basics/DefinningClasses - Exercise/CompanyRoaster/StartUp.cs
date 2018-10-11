using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var employeesCount = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();

        for (int i = 0; i < employeesCount; i++)
        {
            var tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var employee = new Employee(tokens[0],
                decimal.Parse(tokens[1]),
                tokens[2],
                tokens[3]);

            if (tokens.Length > 4)
            {
                var ageOrEmail = tokens[4];

                if (ageOrEmail.Contains("@"))
                {
                    employee.Email = ageOrEmail;
                }
                else
                {
                    employee.Age = int.Parse(ageOrEmail);
                }
            }

            if (tokens.Length > 5)
            {
                employee.Age = int.Parse(tokens[5]);
            }

            employees.Add(employee);
        }

        var result = employees
            .GroupBy(e => e.Department)
            .Select(e => new
            {
                Department = e.Key,
                AvgSalary = e.Average(emp => emp.Salary),
                Empls = e.OrderByDescending(emp => emp.Salary)
            })
            .ToList()
            .OrderByDescending(e => e.AvgSalary)
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Department}");

        foreach (var emp in result.Empls)
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email}{emp.Age}");
        }
    }
}
