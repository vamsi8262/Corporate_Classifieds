using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OfferMicroservice.Models
{
    public partial class Offer
    {
        public int OfferId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }

        public int Likes { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime EngagedDate { get; set; }
        public DateTime ClosedDate { get; set; }

       // public virtual Employee Employee { get; set; }
    }
}
