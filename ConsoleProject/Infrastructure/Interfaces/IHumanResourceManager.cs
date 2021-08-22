using ConsoleProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Interfaces
{
    interface IHumanResourceManager
    {
        List<Department> GetDepartmentbyName(string Name);
        List<Department> Departments { get; }
        void AddDepartment(Department department);
        List<Department> GetDepartment();
        List<Department> EditDepartments(string oldName, string newName);
        void AddEmployee(Employee employee);
        void RemoveEmployee(string employeeNo, string departmentName);
        List<Employee> EditEmployee(string number, string fullName, double Salary, string Position);
    }
}