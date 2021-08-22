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
            int selectInt;
            do
            {
                Console.WriteLine("------------------Xoş Gəlmisiniz-------------------");
                Console.WriteLine();
                Console.WriteLine("1 - Departamentlərin siyahısını göstərmək");
                Console.WriteLine("2 - Departament yaratmaq");
                Console.WriteLine("3 - Departamentde dəyişiklik etmək");
                Console.WriteLine("4 - İşçilərin siyahısını gostərmək");
                Console.WriteLine("5 - Departamentdəki işçilərin siyahısını göstərmək");
                Console.WriteLine("6 - İşçi əlavə etmək");
                Console.WriteLine("7 - İşçi üzərində dəyişiklik etmək");
                Console.WriteLine("8 - Departamentdən işçi silinməsi");
                Console.WriteLine("Seçiminizi edin");
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt))
                {
                    Console.WriteLine("Yalnız ədəd daxil edə bilərsiniz!");
                    select = Console.ReadLine();
                }
                #region Operation Choice
                switch (selectInt)
                {
                    case 1:
                        ShowGetDepartment(_humanResourceManager);
                        break;
                    case 2:
                        ShowAddDepartment(_humanResourceManager);
                        break;
                    case 3:
                        ShowEditDepartment(_humanResourceManager);
                        break;
                    case 4:
                        ShowAllEmployee(_humanResourceManager);
                        break;
                    case 5:
                        ShowEmployeeForDepartment(_humanResourceManager);
                        break;
                    case 6:
                        ShowAddEmployee(_humanResourceManager);
                        break;
                    case 7:
                        ShowEditEmployee(_humanResourceManager);
                        break;
                    case 8:
                        ShowRemoveEmployee(_humanResourceManager);
                        break;
                    default:
                        Console.WriteLine("Düzgün seçim edin");
                        break;
                }
                #endregion
            } while (selectInt != 0);
        }

        #region Choosing Methods
        static void ShowGetDepartment(HumanResourceManager _humanResourceManager) //Show Department Table
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
        static void ShowAddDepartment(HumanResourceManager _humanResourceManager) //Adding Department to Department Table
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
        static void ShowEditDepartment(HumanResourceManager _humanResourceManager) //Changing Department Name
        {
            Console.Write("Departamentin adını daxil edin: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            var list = _humanResourceManager.Departments.Where(d=> d.Name.ToLower() == name.ToLower()).ToList();

            foreach (var item in list)
            {
                
                    Console.Write("Departamentin yeni adını daxil edin: ");
                    string changingName = Console.ReadLine();
                    item.Name = changingName;

                    _humanResourceManager.EditDepartments(name, changingName); // calling EditDepartment Method

                
                

            }


        } //completed
        static void ShowAllEmployee(HumanResourceManager _humanResourceManager) //Show Employee Table
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
        static void ShowEmployeeForDepartment(HumanResourceManager _humanResourceManager) // Find Employee just same Department
        {
            Console.Write("Departamentin adını daxil edin: ");
            string departmentName = Console.ReadLine();

            foreach (Employee emp in _humanResourceManager.Employees)
            {
                if (departmentName.ToLower().Equals(emp.DepartmentName.ToLower()))
                {
                    Console.WriteLine("İşçinin nömrəsi: " + emp.Code);
                    Console.WriteLine("İşçinin adı: " + emp.FullName);
                    Console.WriteLine("İşçinin vəzifəsi: " + emp.Position);
                    Console.WriteLine("İşçinin maaşı: " + emp.Salary);
                    Console.WriteLine();
                }
            }

        } //completed
        static void ShowAddEmployee(HumanResourceManager _humanResourceManager) //Adding Employee to Employees Table
        {
            #region Entering Employee's Information
            Console.WriteLine("------------------İşçi əlavə et---------------");
            Employee employee = new Employee();

            Console.Write("Çalışdığı Departamentin adını qeyd edin: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();

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


            #endregion
            #region Arrow Function
            var list = _humanResourceManager.Employees.Where(e=>e.DepartmentName.ToLower() == departmentName.ToLower()).ToList(); // return employees list where we entered name equals this employees departmentName 
            var count = _humanResourceManager.Employees.Where(e => e.DepartmentName.ToLower() == departmentName.ToLower()).Count(); // return how many employees where we entered name equals this employees departmentName
            double salaryLimit = _humanResourceManager.Departments.Find(d => d.Name.ToLower() == departmentName.ToLower()).SalaryLimit; // return Department salarylimit where we entered name equals this employees departmentName
            int workerLimit = _humanResourceManager.Departments.Find(d => d.Name.ToLower() == departmentName.ToLower()).WorkerLimit; // return Department workerLimit where we entered name equals this employees departmentName

            #endregion
            double total = 0;
            foreach (var item in list)
            {
                total += item.Salary;
            }

            if (total + salary< salaryLimit)
            {
                if (count < workerLimit)
                {
                    employee.Salary = salary;
                    employee.FullName = fullName;
                    employee.Position = position;
                    employee.DepartmentName = departmentName;
                    employee.Code = departmentName.Substring(0, 2).ToUpper() + employee.No;
                    _humanResourceManager.AddEmployee(employee);
                    Console.WriteLine("İşçi əlavə edildi");
                }
                else
                {
                    Console.WriteLine("Departamentdə işçi limiti dolub");
                }
            }
            else
            {
                Console.Write("Maaş limitini keçə bilməzsiniz");
            }
            




        } //completed
        static void ShowEditEmployee(HumanResourceManager _humanResourceManager) //Changing Employee's Information
        {
            #region Entering Employee Information
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string code = Console.ReadLine();
            #endregion

            var list = _humanResourceManager.Employees.Where(e => e.Code.ToLower().Equals(code.ToLower())).ToList();
            foreach (var item in list)
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

                    Console.Write("İşçinin yeni Departamentini daxil edin: ");
                    string departmentName = Console.ReadLine();
                    #endregion

                    item.Code = departmentName.Substring(0, 2).ToUpper() + item.No;
                    item.DepartmentName = departmentName;
                    item.FullName = newFullName;
                    item.Salary = newSalary;
                    item.Position = newPosition;

                    _humanResourceManager.EditEmployee(departmentName, newFullName, newSalary, newPosition, item);
                    Console.WriteLine("Əməliyyat uğurla icra olundu");
                
               
            }
            
        } //completed
        static void ShowRemoveEmployee(HumanResourceManager _humanResourceManager) //Remove Employee from Employee Table
        {
            Employee employee = new Employee();
            Console.WriteLine("---------------İşçini ləğv et----------------");
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string no = Console.ReadLine();
            Console.WriteLine("İşçinin adını daxil edin");
            string departmentName = Console.ReadLine();
            _humanResourceManager.RemoveEmployee(no, departmentName);
        } //completed

        #endregion
    }
}