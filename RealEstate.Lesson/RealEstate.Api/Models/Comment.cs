using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Api.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? IssueId { get; set; }
        public int? UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime? DatePosted { get; set; }

        public virtual Issue Issue { get; set; }
        public virtual User User { get; set; }
    }
}
