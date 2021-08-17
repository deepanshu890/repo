using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamMembers = new HashSet<TeamMembers>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public decimal? Year { get; set; }
        public byte? Members { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TeamMembers> TeamMembers { get; set; }
    }
}
