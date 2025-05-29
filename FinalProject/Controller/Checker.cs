using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Controllers;
using Models;
namespace Controllers
{
    public static class InputChecker
    {
        public static string CheckType(string input)
        {
            if (input != "1" && input != "2")
                throw new ArgumentException("Invalid selection. Choose 1 or 2.");
            return input;
        }
        public static string CheckName(string name)
        {
            if (name.Length < 3 || !char.IsUpper(name[0]))
                throw new ArgumentException("Name must start with an uppercase letter and be at least 3 characters long.");
            return name;
        }

        public static int CheckId(string input)
        {
            if (!int.TryParse(input, out int id))
                throw new FormatException("ID must be a valid integer.");
            if (id < 0)
                throw new ArgumentException("ID cannot be negative.");
            if (EmployeeController.EmployeeExists(id))
                throw new ArgumentException("Employee with ID " + id + " already exists.");
            return id;
        }

        public static string CheckPosition(string pos)
        {
            if (pos.Length < 2 || !char.IsUpper(pos[0]))
                throw new ArgumentException("Position must start with an uppercase letter and be at least 2 characters long.");
            return pos;
        }

        public static DateTime CheckHireDate(string input)
        {
            if (!DateTime.TryParse(input, out DateTime date))
                throw new FormatException("Invalid date format. Please use yyyy-mm-dd.");
            return date;
        }

        public static int CheckExperience(string input)
        {
            if (!int.TryParse(input, out int exp))
                throw new FormatException("Experience must be a valid integer.");
            if (exp < 0)
                throw new ArgumentException("Experience cannot be negative.");
            return exp;
        }

        public static decimal CheckSalary(string input, string fieldName)
        {
            if (!decimal.TryParse(input, out decimal value))
                throw new FormatException($"{fieldName} must be a valid decimal number.");
            if (value <= 0)
                throw new ArgumentException($"{fieldName} must be positive.");
            return value;
        }
        public static decimal CheckRate(string input, string fieldName)
        {
            if (!decimal.TryParse(input, out decimal value))
                throw new FormatException($"{fieldName} must be a valid decimal number.");
            if (value <= 0)
                throw new ArgumentException($"{fieldName} must be positive.");
            return value;
        }

        public static int CheckWorkedHours(string input, string fieldName)
        {
            if (!int.TryParse(input, out int val))
                throw new FormatException($"{fieldName} must be a valid integer.");
            if (val < 0)
                throw new ArgumentException($"{fieldName} cannot be negative.");
            return val;
        }

        public static int CheckWorkedDays(string input, string fieldName)
        {
            if (!int.TryParse(input, out int val))
                throw new FormatException($"{fieldName} must be a valid integer.");
            if (val < 0 || val > 31)
                throw new ArgumentException($"{fieldName} must be between 0 and 31.");
            return val;
        }
    }
}