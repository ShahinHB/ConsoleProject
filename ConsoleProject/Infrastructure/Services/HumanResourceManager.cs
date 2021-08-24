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

        #region Methods
        public void AddDepartment(Department department) //Adding Department to Department Table
        {
            _departments.Add(department);
        }

        public void AddEmployee(Employee employee) //Adding Employee to Employee Table
        {
            _employees.Add(employee);
        }

        public List<Department> EditDepartments(string oldName, string newName) //Change Department Name
        {
            return _departments.FindAll(d => d.Name.ToLower() == oldName.ToLower()).ToList();
        }

        public void EditEmployee(string number, string fullName, double salary, string position, Employee employee) //Change Employee information
        {
            Employee emp = new Employee();
            
        }

        public List<Department> GetDepartment() //Show Department table
        {
            return _departments;
        }

        public void RemoveEmployee(string employeeNo, string departmentName) //Delete employee from Employees table
        {
            var department = _departments.Find(d => d.Name.ToLower() == departmentName.ToLower());

            bool findedEmployee = _employees.Exists(e => e.Code.ToLower() == employeeNo.ToLower());
            var employee = _employees.Find(e => e.Code.ToLower() == employeeNo.ToLower());
            if (findedEmployee == true)
            {
                _employees.Remove(employee);
                Console.WriteLine("İşçi silindi");
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz nömrəyə uyğun işçi tapılmadı");
            }
        }


        #endregion
    }
}