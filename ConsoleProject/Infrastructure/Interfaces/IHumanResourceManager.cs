using ConsoleProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Interfaces
{
    interface IHumanResourceManager
    {
        public List<Department> Departments { get; }
        public void AddDepartment(Department department);
        public List<Department> GetDepartment();
        public void EditDepartments();
        public void AddEmployee(); // parametrlərini yazmalıyam
        public void RemoveEmployee();
        public void EditEmployee(int number, string fullName, double Salary, string Position);
    }
}
