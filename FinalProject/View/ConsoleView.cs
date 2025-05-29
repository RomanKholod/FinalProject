using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Controllers;
using log4net;
using log4net.Config;
using Models;


namespace Views
{
    public class ConsoleView
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public void Start()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            EmployeeController.LoadFromFile("employees.xml");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Show all");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Load from file");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. Remove");
                Console.WriteLine("7. Change position");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                int info;

                switch (choice)
                {
                    case "1":
                        AddEmployeeMenu();
                        break;
                    case "2":
                        foreach (var e in EmployeeController.SortByName())
                            Console.WriteLine("\n" + e);
                        break;
                    case "3":
                        EmployeeController.SaveToFile("employees.xml");
                        break;
                    case "4":
                        EmployeeController.LoadFromFile("employees.xml");
                        break;
                    case "5":
                        Console.Write("Enter name or position to search: ");
                        string query = Console.ReadLine();
                        var found = EmployeeController.SearchByName(query).Concat(EmployeeController.SearchByPosition(query)).ToList();
                        foreach (var e in found) Console.WriteLine(e);
                        break;
                    case "6":
                        Console.Write("Enter employee ID to remove: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out int idToRemove))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer ID.");
                            break;
                        }

                        if (!EmployeeController.EmployeeExists(idToRemove))
                        {
                            Console.WriteLine($"Employee with ID {idToRemove} does not exist.");
                            break;
                        }   

                        EmployeeController.RemoveEmployee(idToRemove);
                        log.Info("Deleted employee " + idToRemove);
                        Console.WriteLine("Employee removed successfully.");
                        break;
                    case "7":
                        Console.Write("Enter employee ID: ");
                        string idInput = Console.ReadLine();

                        if (!int.TryParse(idInput, out int idToChange))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer ID.");
                            break;
                        }

                        if (!EmployeeController.EmployeeExists(idToChange))
                        {
                            Console.WriteLine($"Employee with ID {idToChange} does not exist.");
                            break;
                        }

                        Console.Write("Enter new position: ");
                        string newPosition = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newPosition))
                        {
                            Console.WriteLine("Position cannot be empty.");
                            break;
                        }

                        EmployeeController.ChangePosition(idToChange, newPosition);
                        log.Info("Changed position of " + idToChange);
                        Console.WriteLine("Position changed successfully.");
                        break;
                    case "8":
                        EmployeeController.SaveToFile("employees.xml");
                        exit = true;
                        log.Info("Application ended");
                        break;
                }

            }

        }
        public void AddEmployeeMenu()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            string type;
            while (true)
            {
                Console.WriteLine("1. PartTime employee");
                Console.WriteLine("2. FullTime employee");
                Console.Write("Choose type: ");
                try
                {
                    type = InputChecker.CheckType(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string name;
            while (true)
            {
                Console.Write("Full Name: ");
                try
                {
                    name = InputChecker.CheckName(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int id;
            while (true)
            {
                Console.Write("ID Code: ");
                try
                {
                    id = InputChecker.CheckId(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string pos;
            while (true)
            {
                Console.Write("Position: ");
                try
                {
                    pos = InputChecker.CheckPosition(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            DateTime hire;
            while (true)
            {
                Console.Write("Hire Date (yyyy mm dd): ");
                try
                {
                    hire = InputChecker.CheckHireDate(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int exp;
            while (true)
            {
                Console.Write("Experience (years): ");
                try
                {
                    exp = InputChecker.CheckExperience(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (type == "1")
            {
                decimal rate;
                while (true)
                {
                    Console.Write("Hourly Rate: ");
                    try
                    {
                        rate = InputChecker.CheckRate(Console.ReadLine(), "Hourly rate");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                int hours;
                while (true)
                {
                    Console.Write("Hours Worked: ");
                    try
                    {
                        hours = InputChecker.CheckWorkedHours(Console.ReadLine(), "Hours worked");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                EmployeeController.AddEmployee(new PartTimeEmployee
                {
                    FullName = name,
                    IdCode = id,
                    Position = pos,
                    HireDate = hire,
                    Experience = exp,
                    HourRate = rate,
                    HoursWorked = hours
                });
                log.Info("PartTime Employee" + name + " added successfully");
                Console.WriteLine("PartTime Employee" + name + " added successfully.");
            }

            else
            {
                decimal baseSalary;
                while (true)
                {
                    Console.Write("Base Salary: ");
                    try
                    {
                        baseSalary = InputChecker.CheckSalary(Console.ReadLine(), "Base salary");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                int days;
                while (true)
                {
                    Console.Write("Worked Days: ");
                    try
                    {
                        days = InputChecker.CheckWorkedDays(Console.ReadLine(), "Worked days");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                int sick;
                while (true)
                {
                    Console.Write("Sick Days: ");
                    try
                    {
                        sick = InputChecker.CheckWorkedDays(Console.ReadLine(), "Sick days");
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                EmployeeController.AddEmployee(new FullTimeEmployee
                {
                    FullName = name,
                    IdCode = id,
                    Position = pos,
                    HireDate = hire,
                    Experience = exp,
                    BaseSalary = baseSalary,
                    WorkedDays = days,
                    SickDays = sick
                });
                log.Info("FullTime Employee" + name + " added successfully");
                Console.WriteLine("FullTime Employee" + name + " added successfully.");
            }

        }
    }
}

