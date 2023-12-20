using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Api.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Houses = new HashSet<House>();
            Issues = new HashSet<Issue>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<House> Houses { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
