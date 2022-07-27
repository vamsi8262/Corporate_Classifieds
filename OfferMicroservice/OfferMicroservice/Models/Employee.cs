using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OfferMicroservice.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Offer = new HashSet<Offer>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
    }
}
