using ConsoleProject.Infrastructure.Services;
using System;
using System.Text;
using ConsoleTables;
using ConsoleProject.Infrastructure.Models;

namespace ConsoleProject
{
    class Program
    {
        private static HumanResourceManager _humanResourceManager = new HumanResourceManager();
        public Program()
        {
            _humanResourceManager = new HumanResourceManager();
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
            } while (selectInt != 0);
        }
        static void ShowGetDepartment()
        {
            var table = new ConsoleTable ("Adı", "İşçi limiti", "Maaş limiti");
            var i = 1;
            foreach (var item in _humanResourceManager.Departments)
            {
                table.AddRow(item.Name, item.WorkerLimit, item.SalaryLimit);
                i++;
            }
            table.Write();
        } //completed
        static void ShowAddDepartment()
        {

        } 
        static void ShowEditDepartment()
        {

        }
        static void ShowAllEmployee()
        {
            var table = new ConsoleTable("№", "Adı","Vəzifəsi","İşlədiyi Departament","Maaş");
            var i = 1;
            foreach (var item in _humanResourceManager.Employees)
            {
                table.AddRow(item.No, item.FullName,item.Position, item.DepartmentName, item.Salary);
                i++;
            }
            table.Write();
        } //completed
        static void ShowEmployeeForDepartment()
        {

        }
        static void ShowAddEmployee()
        {
            Console.WriteLine("------------------Məhsul əlavə et---------------");
            Employee employee = new Employee();

            Console.Write("İşçinin adını və Soyadını daxil edin: ");
            string fullName = Console.ReadLine();
            employee.FullName = fullName;
            Console.WriteLine();

            Console.Write("İşçinin vəzifəsini daxil edin: ");
            string position = Console.ReadLine();
            employee.Position = position;
            Console.WriteLine();

            Console.Write("Çalışdığı Departamentin adını qeyd edin: ");
            string departmentName = Console.ReadLine();
            employee.DepartmentName = departmentName;
            Console.WriteLine();

            Console.Write("Maaşını daxil edin: ");

            string salaryInput = Console.ReadLine();
            double salary;

            while (!double.TryParse(salaryInput, out salary))
            {
                Console.WriteLine("Yalnız rəqəm daxil edə bilərsiniz");
                salaryInput = Console.ReadLine();
            }

            employee.Salary = salary;

            employee.Code = employee.DepartmentName.Substring(0, 2).ToUpper() + employee.No;


        } //completed
        static void ShowEditEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string code = Console.ReadLine();

            Console.WriteLine("İşçinin adını daxil edin");
            string fullName = Console.ReadLine();

            Console.WriteLine("İşçinin vəzifəsini daxil edin");
            string position = Console.ReadLine();

            Console.WriteLine("İşçinin maaşını daxil edin");
            double salary = Convert.ToDouble(Console.ReadLine());

            if (code.ToLower().Equals(employee.Code.ToLower()) && fullName.ToLower().Equals(employee.FullName.ToLower()) && position.ToLower().Equals(employee.Position.ToLower()) && salary.Equals(employee.Salary ) )
            {
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

                employee.Code = departmentName.Substring(0,2).ToUpper() + employee.No;
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
        static void ShowRemoveEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("---------------İşçini ləğv et----------------");
            Console.WriteLine("İşçinin nömrəsini daxil edin");
            string no = Console.ReadLine();
            string departmentName = Console.ReadLine();
            _humanResourceManager.RemoveEmployee(no, departmentName);
        } //completed

    }
}
