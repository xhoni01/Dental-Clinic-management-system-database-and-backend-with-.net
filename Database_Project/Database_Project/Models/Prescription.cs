using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Prescription
    {
        public int PescriptionId { get; set; }
        public int TreatmentId { get; set; }
        public string PrescriptionInfo { get; set; }

    }
}