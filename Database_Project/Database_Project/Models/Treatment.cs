using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Treatment
    {
        public int TreatmentId{ get; set;}
        public string TreatmentDescription { get; set;}
        public int TreatmentCost { get; set;}
    }
}