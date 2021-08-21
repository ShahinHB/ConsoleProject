using ConsoleProject.Infrastructure.Interfaces;
using ConsoleProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleProject.Infrastructure.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private List<Department> _departments;
        private List<Employee> _employees;
        public List<Department> Departments => _departments;
        public List<Employee> Employees => _employees;
        public HumanResourceManager()
        {
            _departments = new List<Department>();
            _employees = new List<Employee>();
        }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public List<Department> EditDepartments(string oldName, string newName)
        {
              return _departments.FindAll(d=>d.Name == oldName);
        }

        public List<Employee> EditEmployee(string number, string fullName, double salary, string position)
        {
            return _employees.FindAll(e => e.Code.ToLower() == number.ToLower() && e.FullName.ToLower() == fullName.ToLower() && e.Salary == salary && e.Position.ToLower() == position.ToLower()).ToList();
        }

        public List<Department> GetDepartment()
        {
            return _departments;
        }

        public void RemoveEmployee(string employeeNo, string departmentName)
        {
            var EmployeeList = _employees.ToList();
            var RemovedItem = _employees.Find(e => e.Code.ToLower() == employeeNo.ToLower() && e.DepartmentName.ToLower() == departmentName.ToLower());
            _employees.Remove(RemovedItem);
        }
    }
}
