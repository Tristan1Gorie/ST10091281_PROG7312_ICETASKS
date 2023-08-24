using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ICE2
{
    internal class Employee
    {
        public string Surname { get; set; }
        public int departmentID { get; set; }

        public Employee(string surname, int departmentID)
        {
            this.Surname = surname;
            this.departmentID = departmentID;
        }

        public Employee()
        {
            
        }

        
    }
}
