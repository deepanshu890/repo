using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamMembers = new HashSet<TeamMembers>();
            AccountTeam = new HashSet<AccountTeam>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public decimal? Year { get; set; }
        public byte? Members { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TeamMembers> TeamMembers { get; set; }
        public virtual ICollection<AccountTeam> AccountTeam { get; set; }
    }
}
