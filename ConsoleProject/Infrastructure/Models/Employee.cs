using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Models
{
    class Employee
    {
        private static int _no=1000;
        public string Name { get; set; }
        private string _position;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (value.Length >= 2)
                {
                    Position = _position;
                }
                else
                {
                    Console.WriteLine("Departamentin adı minimum 2 hərfdən ibarət olmalıdır");
                }
            }
        }
        private double _salary;
        public double Salary { get
            {
                return _salary;
            }
            set
            {
                if (value > 250)
                {
                    Salary = _salary;
                }
                else
                {
                    Console.WriteLine("Maaş 250 manatdan yuxarı olmalıdır");
                }
            }
        }
        public string DepartmentName { get; set; }
        public string No { get; set; }
        public Employee()
        {
            _no++;
            No = DepartmentName.Substring(0,2).ToUpper() + _no;
        }
    }
}
