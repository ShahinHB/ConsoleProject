using ConsoleProject.Infrastructure.Interfaces;
using ConsoleProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public List<Department> Departments => throw new NotImplementedException();

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee()
        {
            throw new NotImplementedException();
        }

        public void EditDepartments()
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(int number, string fullName, double Salary, string Position)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartment()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
