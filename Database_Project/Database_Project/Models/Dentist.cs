using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Dentist
    {
        public int DentistId { get; set; }
        public string DentistRole { get; set; }
        public int EmployeeId { get; set; }
    }
}