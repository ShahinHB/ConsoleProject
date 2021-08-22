using ConsoleProject.Infrastructure.Services;
using System;
using System.Text;
using ConsoleTables;
using ConsoleProject.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProject
{
    class Program
    {
        private static HumanResourceManager _humanResourceManager = new HumanResourceManager();
        public Program()
        {
            HumanResourceManager _humanResourceManager = new HumanResourceManager();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            double selectInt;
            do
            {
                Console.WriteLine("------------------Xoş Gəlmisiniz-------------------");
                Console.WriteLine();
                Console.WriteLine("1.1 - Departamentlərin siyahısını göstərmək");
                Console.WriteLine("1.2 - Departament yaratmaq");
                Console.WriteLine("1.3 - Departamentde dəyişiklik etmək");
                Console.WriteLine("2.1 - İşçilərin siyahısını gostərmək");
                Console.WriteLine("2.2 - Departamentdəki işçilərin siyahısını göstərmək");
                Console.WriteLine("2.3 - İşçi əlavə etmək");
                Console.WriteLine("2.4 - İşçi üzərində dəyişiklik etmək");
                Console.WriteLine("2.5 - Departamentdən işçi silinməsi");
                Console.WriteLine("Seçiminizi edin");
                string select = Console.ReadLine();

                while (!double.TryParse(select, out selectInt))
                {
                    Console.WriteLine("Yalnız ədəd daxil edə bilərsiniz!");
                    select = Console.ReadLine();
                }
                #region Operation Choice
                switch (selectInt)
                {
                    case 1.1:
                        ShowGetDepartment();
                        break;
                    case 1.2:
                        ShowAddDepartment();
                        break;
                    case 1.3:
                        ShowEditDepartment();
                        break;
                    case 2.1:
                        ShowAllEmployee();
                        break;
                    case 2.2:
                        ShowEmployeeForDepartment();
                        break;
                    case 2.3:
                        ShowAddEmployee();
                        break;
                    case 2.4:
                        ShowEditEmployee();
                        break;
                    case 2.5:
                        ShowRemoveEmployee();
                        break;
                    default:
                        Console.WriteLine("Düzgün seçim edin");
                        break;
                }
                #endregion
            } while (selectInt != 0);
        }

        #region Choosing Methods
        static void ShowGetDepartment() //Show Department Table
        {
            var table = new ConsoleTable("Sıra", "Adı", "İşçi limiti", "Maaş limiti", "İşçi sayı");
            var i = 1;
            #region Department Table
            foreach (var item in _humanResourceManager.Departments)
            {
             

                table.AddRow(i, item.Name, item.WorkerLimit, item.SalaryLimit, _humanResourceManager.Employees.FindAll(e=>e.DepartmentName == item.Name).Count);
                i++;
                
            }
            table.Write();
            #endregion
        } //completed
        static void ShowAddDepartment() //Adding Department to Department Table
        {
            Department department = new Department();

            #region Entering Information
            Console.Write("Departamentin adını daxil edin: ");
            string departmentName = Console.ReadLine();
            department.Name = departmentName;

            Console.Write("Departamentin işçi limitini daxil edin: ");
            string inputWorkerLimit = Console.ReadLine();
            int WorkerLimit;

            while (!int.TryParse(inputWorkerLimit, out WorkerLimit))
            {
                Console.WriteLine("Rəqəm daxil edin!");
                inputWorkerLimit = Console.ReadLine();
            }
            department.WorkerLimit = WorkerLimit;

            Console.Write("Maaş limitini daxil edin: ");
            string inputSalaryLimit = Console.ReadLine();
            double salaryLimit;
            while (!double.TryParse(inputSalaryLimit, out salaryLimit))
            {
                Console.WriteLine("Rəqəm daxil edin!");
            }
            department.SalaryLimit = salaryLimit;
            #endregion

            _humanResourceManager.AddDepartment(department); //Calling AddDepartment Method
        }  //completed
        static void ShowEditDepartment() //Changing Department Name
        {
            Department department = new Department();
            Console.Write("Departamentin adını daxil edin: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            if (name.ToLower().Equals(department.Name.ToLower()))
            {
                Console.Write("Departamentin yeni adını daxil edin: ");
                string changingName = Console.ReadLine();
                department.Name = changingName;

                _humanResourceManager.EditDepartments(name, changingName); // calling EditDepartment Method

            }
            else
            {
                Console.WriteLine("Bu adda departament tapılmadı"); //not Finded Departament
            }
        } //completed
        static void ShowAllEmployee() //Show Employee Table
        {
            var table = new ConsoleTable("Sıra", "İşçi nömrəsi", "Adı", "Vəzifəsi", "İşlədiyi Departament", "Maaş");
            var i = 1;

            #region Employee Table
            foreach (var item in _humanResourceManager.Employees)
            {
                table.AddRow(i, item.Code, item.FullName, item.Position, item.DepartmentName, item.Salary);
                i++;
            }
            #endregion
            table.Write();
        } //completed
        static void ShowEmployeeForDepartment() // Find Employee just same Department
        {

            string departmentName = Console.ReadLine();

            foreach (Employee emp in _humanResourceManager.Employees)
            {
                if (departmentName.ToLower().Equals(emp.DepartmentName))
                {
                    Console.WriteLine(emp.Code);
                    Console.WriteLine(emp.FullName);
                    Console.WriteLine(emp.Position);
                    Console.WriteLine(emp.Salary);
                }
            }

        } //completed
        static void ShowAddEmployee() //Adding Employee to Employees Table
        {
            #region Entering Employee's Information
            Console.WriteLine("------------------Məhsul əlavə et---------------");
            Employee employee = new Employee();
            //var list = _humanResourceManager.Employees.Where(e => e.DepartmentName.ToLower() == item.Name).ToList();
            Console.Write("İşçinin adını və Soyadını daxil edin: ");
            string fullName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("İşçinin vəzifəsini daxil edin: ");
            string position = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Maaşını daxil edin: ");
            string salaryInput = Console.ReadLine();
            double salary;

            while (!double.TryParse(salaryInput, out salary))
            {
                Console.WriteLine("Yalnız rəqəm daxil edə bilərsiniz");
                salaryInput = Console.ReadLine();
            }

            Console.Write("Çalışdığı Departamentin adını qeyd edin: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();
            #endregion

            var list = _humanResourceManager.Employees.Where(e=>e.DepartmentName == departmentName).ToList();
            var count = _humanResourceManager.Employees.Where(e => e.DepartmentName == departmentName).Count();
            var salaryLimit = _humanResourceManager.Departments.Find(d => d.Name == departmentName).SalaryLimit;
            var workerLimit = _humanResourceManager.Departments.Find(d => d.Name == departmentName).WorkerLimit;


            double total = 0;
            foreach (var item in list)
            {
                total += item.Salary;
            }

            if (total < salaryLimit && count < workerLimit)
            {
                employee.Salary = salary;
                employee.FullName = fullName;
                employee.Position = position;
                employee.DepartmentName = departmentName;
            }
            else
            {
                Console.WriteLine("İşçi əlavə edilə bilmədi. Departamentdəki maaş limiti yaxud işçi limiti dolmuşdur");
            }
            

            employee.Code = employee.DepartmentName.Substring(0, 2).ToUpper() + employee.No;

            _humanResourceManager.AddEmployee(employee);

        } //completed
        static void ShowEditEmployee() //Changing Employee's Information
        {
            #region Entering Employee Information
            Employee employee = new Employee();
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string code = Console.ReadLine();

            Console.WriteLine("İşçinin adını daxil edin");
            string fullName = Console.ReadLine();

            Console.WriteLine("İşçinin vəzifəsini daxil edin");
            string position = Console.ReadLine();

            Console.WriteLine("İşçinin maaşını daxil edin");
            double salary = Convert.ToDouble(Console.ReadLine());
            #endregion


            if (code.ToLower().Equals(employee.Code.ToLower()) && fullName.ToLower().Equals(employee.FullName.ToLower()) && position.ToLower().Equals(employee.Position.ToLower()) && salary.Equals(employee.Salary)) //Checked Information
            {
                #region Entering new datas
                Console.Write("İşçinin yeni adını daxil edin: ");
                string newFullName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("İşçinin yeni vəzifəsini daxil edin: ");
                string newPosition = Console.ReadLine();
                Console.WriteLine();

                Console.Write("İşçinin yeni maaşını daxil edin: ");
                string newSalaryInput = Console.ReadLine();
                double newSalary;
                Console.WriteLine();

                while (!double.TryParse(newSalaryInput, out newSalary))
                {
                    Console.WriteLine();
                    Console.Write("Yalnız rəqəm daxil edə bilərsiniz");
                    newSalaryInput = Console.ReadLine();
                    Console.WriteLine();
                }

                Console.Write("İşçinin yeni iş yerini daxil edin: ");
                string departmentName = Console.ReadLine();
                #endregion

                employee.Code = departmentName.Substring(0, 2).ToUpper() + employee.No;
                employee.DepartmentName = departmentName;
                employee.FullName = newFullName;
                employee.Salary = newSalary;
                employee.Position = newPosition;

                Console.WriteLine("Əməliyyat uğurla icra olundu");
            }
            else
            {
                Console.WriteLine("İşçi tapılmadı");
            }
        } //completed
        static void ShowRemoveEmployee() //Remove Employee from Employee Table
        {
            Employee employee = new Employee();
            Console.WriteLine("---------------İşçini ləğv et----------------");
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string no = Console.ReadLine();
            string departmentName = Console.ReadLine();
            _humanResourceManager.RemoveEmployee(no, departmentName);
        } //completed

        #endregion
    }
}