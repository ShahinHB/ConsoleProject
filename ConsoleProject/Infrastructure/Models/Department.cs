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
        public Employee Employees { get; set; }
        public  double CalcSalaryAverage()
        {
            return 6;
        }

    }
}
