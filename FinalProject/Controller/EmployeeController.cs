using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using System.Xml.Serialization;
using log4net;
using log4net.Config;
using System.Reflection;

namespace Controllers
{
    public static class EmployeeController
    {

        public static List<Employee> Employees { get; set; } = new();

        public static void AddEmployee(Employee emp) => Employees.Add(emp);

        public static  void RemoveEmployee(int idCode) =>
            Employees.RemoveAll(e => e.IdCode == idCode);

        public static void ChangePosition(int idCode, string newPosition)
        {
            var emp = Employees.FirstOrDefault(e => e.IdCode == idCode);
            if (emp != null) emp.Position = newPosition;
        }

        public static void SaveToFile(string path)
        {
            XmlSerializer serializer = new(typeof(List<Employee>), [typeof(PartTimeEmployee), typeof(FullTimeEmployee)]);
            using var stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, Employees);
        }

        public static void LoadFromFile(string path)
        {
            if (File.Exists(path))
            {
                XmlSerializer serializer = new(typeof(List<Employee>), [typeof(PartTimeEmployee), typeof(FullTimeEmployee)]);
                using var stream = new FileStream(path, FileMode.Open);
                Employees = (List<Employee>)serializer.Deserialize(stream);
            }
        }

        public static List<Employee> SearchByName(string surname) =>
            Employees.Where(e => e.FullName.Contains(surname, StringComparison.OrdinalIgnoreCase)).ToList();

        public static List<Employee> SearchByPosition(string position) =>
            Employees.Where(e => e.Position.Contains(position, StringComparison.OrdinalIgnoreCase)).ToList();

        public static List<Employee> SortByName() =>
            Employees.OrderBy(e => e.FullName).ToList();
        public static bool EmployeeExists(int id)
        {
            return Employees.Exists(e => e.IdCode == id);
        }
    }
}
