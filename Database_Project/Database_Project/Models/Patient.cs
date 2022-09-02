using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Patient
    {
        public int PatientPersonalNumber { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        public string PatientState { get; set; }
        public string PatientCity { get; set; }
        public string PatientStreet { get; set; }
        public int PatientAreaCode { get; set; }
        public int PatientPhoneNumber { get; set; }
        public string PatientEmail { get; set; }
    }
}