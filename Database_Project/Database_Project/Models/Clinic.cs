using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Clinic
    {
       public int ClinicId { get; set; }
       public string ClinicName { get; set; }
       public string ClinicState { get; set; }
       public string ClinicCity { get; set; }
       public string ClinicStreet { get; set; }
       public int ClinicAreaCode { get; set; }
       public int ClinicPhoneNumber { get; set; } 
    }
}