using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Models
{
    class Employee
    {
        private static int _no=1000;
        public string FullName { get; set; }
        private string _position;
        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                while (value.Length < 2)
                {
                    Console.WriteLine("Vəzifənin adı minimum 2 hərfdən ibarət olmalıdır");
                    Console.Write("Yenidən daxil edin: ");
                    value = Console.ReadLine();
                    Console.WriteLine();
                }
                _position = value;
                Console.WriteLine();
            }
        }
        private double _salary;
        public double Salary { 
            get
            {
                return _salary;
            }
            set
            {
                while (value < 250)
                {
                    Console.WriteLine("Maaş 250 manatdan yuxarı olmalıdır");
                    Console.Write("Yenidən daxil edin: ");
                    value = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();
                }
                _salary = value;
                Console.WriteLine();
            }
        }
        public string DepartmentName { get; set; }
        public int No { get; set; }
        public string Code { get; set; }

        public Employee()
        {
            _no++;
            No = _no;
        }
    }
}
