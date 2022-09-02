using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int DentistId { get; set; }
        public int PatientPersonalNumber  { get; set; }
    }
}