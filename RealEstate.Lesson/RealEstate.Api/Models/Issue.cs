using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Api.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Comments = new HashSet<Comment>();
        }

        public int IssueId { get; set; }
        public int? HouseId { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? ReportedDate { get; set; }

        public virtual House House { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
