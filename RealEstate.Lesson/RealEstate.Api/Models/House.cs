using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Api.Models
{
    public partial class House
    {
        public House()
        {
            Issues = new HashSet<Issue>();
        }

        public int HouseId { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string BuildingNumber { get; set; }
        public bool? IsFlat { get; set; }
        public string Flat { get; set; }
        public int? OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
