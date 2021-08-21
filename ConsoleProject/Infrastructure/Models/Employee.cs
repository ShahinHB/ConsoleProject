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
                }
                _position = value;


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
                if (value > 250)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Maaş 250 manatdan yuxarı olmalıdır");
                }
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
