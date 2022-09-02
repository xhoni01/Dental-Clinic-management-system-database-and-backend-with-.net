using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Employee
    {
        public int EmployeeId { get; set;}
        public string EmployeeFName { get; set;}
        public string EmployeeLName { get; set;}
        public DateTime EmployeeDOB { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeStreet { get; set; }
        public int EmployeeAreaCode { get; set; }
        public int EmployeePhoneNumber { get; set; }
        public int ClinicId { get; set; }

    }
}