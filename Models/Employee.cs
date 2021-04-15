using System;
using System.Collections.Generic;

#nullable disable

namespace Product_API2.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Empname { get; set; }
        public int? Salary { get; set; }
        public string Address { get; set; }
    }
}
