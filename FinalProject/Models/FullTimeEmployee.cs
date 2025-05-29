using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FullTimeEmployee : Employee
    {
        public decimal BaseSalary { get; set; }
        public int WorkedDays { get; set; }
        public int SickDays { get; set; }

        public override decimal CalculateSalary()
        {
            return BaseSalary + Experience * 50;
        }
        public decimal CalculateBonus()
        {
            return Experience * 50;
        }


        public override string ToString()
        {
            return base.ToString() + $", Worked Days: {WorkedDays}, Sick Days: {SickDays}, Base Salary: {BaseSalary}, Salary: {CalculateSalary()}, Expiriance Bonus: {CalculateBonus()}";
        }
    }
}

