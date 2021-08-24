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
        #region Private List
        private List<Department> _departments;
        private List<Employee> _employees;
        #endregion
        #region Public List
        public List<Department> Departments => _departments;
        public List<Employee> Employees => _employees;
        #endregion
        public HumanResourceManager()
        {
            _departments = new List<Department>();
            _employees = new List<Employee>();

        }

        #region Methods
        #region Adding Methods
        public void AddDepartment(Department department) //Adding Department to Department Table
        {
            _departments.Add(department);
        }

        public void AddEmployee(Employee employee) //Adding Employee to Employee Table
        {
            _employees.Add(employee);
        }
        #endregion

        #region Editing Methods
        public List<Department> EditDepartments(string oldName, string newName) //Change Department Name
        {
            return _departments.FindAll(d => d.Name.ToLower() == oldName.ToLower()).ToList(); // we finding where entering Department Name have Department List

        }

        public void EditEmployee(string number, string fullName, double salary, string position, Employee employee) //Change Employee information
        {
            Employee emp = new Employee();
        }

        #endregion
        public List<Department> GetDepartment() //Show Department table
        {
            return _departments;
        }

        public void RemoveEmployee(string employeeNo, string departmentName) //Delete employee from Employees table
        {

            bool findedEmployee = _employees.Exists(e => e.Code.ToLower() == employeeNo.ToLower()); // checked according to the number entered have Employee List or not
            var employee = _employees.Find(e => e.Code.ToLower() == employeeNo.ToLower()); //finding this employee
            
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