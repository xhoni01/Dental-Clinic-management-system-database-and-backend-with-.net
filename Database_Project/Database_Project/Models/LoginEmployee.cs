using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class LoginEmployee
    {
        public string username { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeRole { get; set; }

    }
}