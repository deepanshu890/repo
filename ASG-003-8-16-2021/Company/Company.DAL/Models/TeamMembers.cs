using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class TeamMembers
    {
        public int Sno { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public string Designation { get; set; }

        public virtual Team Team { get; set; }
        public virtual Users User { get; set; }
    }
}
