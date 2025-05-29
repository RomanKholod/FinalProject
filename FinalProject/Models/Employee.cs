using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(PartTimeEmployee))]
    [XmlInclude(typeof(FullTimeEmployee))]
    public abstract class Employee
    {
        public string FullName { get; set; }
        public int IdCode { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public int Experience { get; set; }

        public abstract decimal CalculateSalary();

        public override string ToString()
        {
            return $"{FullName}, Position: {Position}, ID: {IdCode}, Hire Date: {HireDate.ToShortDateString()}, Experience: {Experience} years";
        }
    }
}

