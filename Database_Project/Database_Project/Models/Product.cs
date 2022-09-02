using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQOH   { get; set; }
        public int ProductMin   { get; set; }
        public int ProductReorder { get; set; }
        public int ClinicId { get; set; }
    }
}