using ConsoleProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Infrastructure.Interfaces
{
    interface IHumanResourceManager
    {
        List<Department> Departments { get; }
        #region Deparment's Method
        void AddDepartment(Department department);
        List<Department> GetDepartment();
        List<Department> EditDepartments(string oldName, string newName);
        #endregion
        #region Employee's method
        void AddEmployee(Employee employee);
        void RemoveEmployee(string employeeNo, string departmentName);
        void EditEmployee(string number, string fullName, double Salary, string Position, Employee employee);
        #endregion
    }
}