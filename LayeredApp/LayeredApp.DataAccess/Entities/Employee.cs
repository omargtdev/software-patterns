using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredApp.DataAccess.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Birthday { get; set; }
    }
}
