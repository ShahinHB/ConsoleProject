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
            Console.OutputEncoding = Encoding.UTF8; //This commend help us we use Azeri-Latin letter

            int selectInt;
            do
            {
                #region Main menu
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
                #endregion
                string select = Console.ReadLine();

                while (!int.TryParse(select, out selectInt)) // Check input is number or not
                {
                    Console.WriteLine("Yalnız ədəd daxil edə bilərsiniz!");
                    select = Console.ReadLine();
                }
                #region Main Menu Command
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
            Console.WriteLine("-------------------Departamentlər siyahısı-----------------");
            var table = new ConsoleTable("Sıra", "Adı", "İşçi limiti", "Maaş limiti", "İşçi sayı"); //ConsoleTable is a package (Download from Nuget)
            var i = 1;
            #region Department Table
            foreach (var item in _humanResourceManager.Departments)
            {
                table.AddRow(i, item.Name.ToUpper(), item.WorkerLimit, item.SalaryLimit, _humanResourceManager.Employees.FindAll(e => e.DepartmentName.ToLower() == item.Name.ToLower()).Count);
                i++;
            }
            table.Write();
            Console.WriteLine();
            #endregion
        } //completed
        static void ShowAddDepartment(HumanResourceManager _humanResourceManager) //Adding Department to Department Table
        {
            Console.WriteLine("------------------Yeni Departament əlavə et-------------------");
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
            Console.WriteLine();

            _humanResourceManager.AddDepartment(department); //Calling AddDepartment Method
        }  //completed
        static void ShowEditDepartment(HumanResourceManager _humanResourceManager) //Changing Department Name
        {
            Console.Write("Departamentin adını daxil edin: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            var list = _humanResourceManager.Departments.Where(d => d.Name.ToLower() == name.ToLower()).ToList();

            foreach (var item in list)
            {
                Console.Write("Departamentin yeni adını daxil edin: ");
                string changingName = Console.ReadLine();
                item.Name = changingName;

                _humanResourceManager.EditDepartments(name, changingName); // calling EditDepartment Method
                Employee employee = new Employee();
                var newList = _humanResourceManager.Employees.FindAll(e => e.DepartmentName.ToLower() == name.ToLower()).ToList(); //We use this commands for old employees Code and departmentName is not changed

                foreach (var elem in newList)
                {
                    elem.DepartmentName = changingName;
                    elem.Code = changingName.Substring(0,2).ToUpper() + elem.No;
                    //all employees data has changed
                }

            }
            Console.WriteLine();

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
            Console.WriteLine();

        } //completed
        static void ShowEmployeeForDepartment(HumanResourceManager _humanResourceManager) // Find Employee just same Department
        {
            Console.Write("Departamentin adını daxil edin: ");
            string departmentName = Console.ReadLine();

            bool check = _humanResourceManager.Departments.Exists(d=>d.Name == departmentName); // we checked entering Department Name have Department List or not

            if (check == true)
            {
                foreach (Employee emp in _humanResourceManager.Employees)
                {
                    if (emp.DepartmentName.ToLower() == departmentName.ToLower())
                    {
                        #region Result
                        Console.WriteLine("İşçinin nömrəsi: " + emp.Code);
                        Console.WriteLine("İşçinin adı: " + emp.FullName);
                        Console.WriteLine("İşçinin vəzifəsi: " + emp.Position);
                        Console.WriteLine("İşçinin maaşı: " + emp.Salary);
                        Console.WriteLine();
                        #endregion
                    }
                }
            }
            else
            {
                Console.WriteLine("Bu adda Departament yoxdur");
            }
            Console.WriteLine();

        } //completed
        static void ShowAddEmployee(HumanResourceManager _humanResourceManager) //Adding Employee to Employees Table
        {
            #region Entering Employee's Information

            Console.WriteLine("------------------İşçi əlavə et---------------");
            Employee employee = new Employee();

            Console.Write("Çalışdığı Departamentin adını qeyd edin: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();
            employee.DepartmentName = departmentName;

            Console.Write("İşçinin adını və Soyadını daxil edin: ");
            string fullName = Console.ReadLine();
            Console.WriteLine();
            employee.FullName = fullName;

            Console.Write("İşçinin vəzifəsini daxil edin: ");
            string position = Console.ReadLine();
            employee.Position = position;

            Console.Write("Maaşını daxil edin: ");
            string salaryInput = Console.ReadLine();
            double salary;

            while (!double.TryParse(salaryInput, out salary))
            {
                Console.WriteLine();
                Console.WriteLine("Yalnız rəqəm daxil edə bilərsiniz");
                salaryInput = Console.ReadLine();
            }
            employee.Salary = salary;

            #endregion


            bool check = _humanResourceManager.Departments.Exists(d => d.Name.ToLower() == departmentName.ToLower());
            var list = _humanResourceManager.Employees.Where(e => e.DepartmentName.ToLower() == departmentName.ToLower()).ToList(); // return employees list where we entered name equals this employees departmentName 
            var count = _humanResourceManager.Employees.Where(e => e.DepartmentName.ToLower() == departmentName.ToLower()).Count(); // return how many employees where we entered name equals this employees departmentName
            
            double total = 0;
            foreach (var item in list)
            {
                total += item.Salary;
            }
            if (check == true)
            {
                double salaryLimit = _humanResourceManager.Departments.Find(d => d.Name.ToLower() == departmentName.ToLower()).SalaryLimit; // return Department salarylimit where we entered name equals this employees departmentName
                int workerLimit = _humanResourceManager.Departments.Find(d => d.Name.ToLower() == departmentName.ToLower()).WorkerLimit; // return Department workerLimit where we entered name equals this employees departmentName

                if (total + salary < salaryLimit)
                {
                    if (count < workerLimit)
                    {
                        employee.Code = departmentName.Substring(0, 2).ToUpper() + employee.No;
                        _humanResourceManager.AddEmployee(employee);
                        Console.WriteLine();
                        Console.WriteLine("İşçi əlavə edildi");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Departamentdə işçi limiti dolub");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Maaş limitini keçə bilməzsiniz");
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz adda Departament tapılmadı");
            }
            Console.WriteLine();

        } //completed
        static void ShowEditEmployee(HumanResourceManager _humanResourceManager) //Changing Employee's Information
        {
            Console.Write("İşçinin nömrəsini daxil edin: "); 
            string code = Console.ReadLine(); //Entering employee Code(Number)
            Console.WriteLine();

            var list = _humanResourceManager.Employees.Where(e => e.Code.ToLower().Equals(code.ToLower())).ToList();

            foreach (var item in list)
            {
                Console.Write("İşçinin yeni Departamentini daxil edin: "); 
                string departmentName = Console.ReadLine();
                bool check = _humanResourceManager.Departments.Exists(d=>d.Name.ToLower() == departmentName.ToLower()); //we checked entering Department Name have Department List or not

                if (check == true)
                {
                    item.DepartmentName = departmentName;
                    #region Entering new datas
                    Console.Write("İşçinin yeni adını daxil edin: ");
                    string newFullName = Console.ReadLine();
                    Console.WriteLine();
                    item.FullName = newFullName;

                    Console.Write("İşçinin yeni vəzifəsini daxil edin: ");
                    string newPosition = Console.ReadLine();
                    Console.WriteLine();
                    item.Position = newPosition;

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
                    item.Salary = newSalary;
                    item.Code = departmentName.Substring(0, 2).ToUpper() + item.No; //employee Code(Number)

                    _humanResourceManager.EditEmployee(departmentName, newFullName, newSalary, newPosition, item);
                    Console.WriteLine("Əməliyyat uğurla icra olundu");
                }
                else
                {
                    Console.WriteLine("Axtardığınız adda Departament tapılmadı");
                }

                #endregion
               
            }
            Console.WriteLine();
        } //completed
        static void ShowRemoveEmployee(HumanResourceManager _humanResourceManager) //Remove Employee from Employee Table
        {
            Department department = new Department();
            Employee employee = new Employee();
            Console.WriteLine();
            Console.Write("Departamentin adını daxil edin: ");
            string departmentName = Console.ReadLine();
            department.Name = departmentName;

            bool check = _humanResourceManager.Departments.Exists(d => d.Name.ToLower() == departmentName.ToLower()); //we checked entering Department Name have Department List or not

            if (check == true)
            {
                Console.Write("İşçinin nömrəsini daxil edin: ");
                string no = Console.ReadLine();
                employee.Code = no;

                _humanResourceManager.RemoveEmployee(no, departmentName);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz adda Departament tapılmadı");
            }
            
        } //completed

        #endregion
    }
}