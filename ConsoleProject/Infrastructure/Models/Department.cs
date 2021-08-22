using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public List<Employee> Employees;
        public  double CalcSalaryAverage()
        {
            double sumSalary=0;
            double averageSalary=0;

            foreach (Employee item in Employees)
            {
                sumSalary = sumSalary + item.Salary;

            }
            if (Employees.Count > 0)
            {
                averageSalary = sumSalary / Employees.Count;
            }
            return averageSalary;
        }

    }
}