using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PartTimeEmployee : Employee
    {
        public decimal HourRate { get; set; }
        public int HoursWorked { get; set; }

        public override decimal CalculateSalary()
        {
            return HourRate * HoursWorked;
        }

        public override string ToString()
        {
            return base.ToString() + $", Hours Worked: {HoursWorked}, Hourly Rate: {HourRate}, Salary: {CalculateSalary()}";
        }
    }
}

