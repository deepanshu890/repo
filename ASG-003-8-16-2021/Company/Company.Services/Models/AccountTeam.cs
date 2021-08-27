using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Services.Models
{
    public class AccountTeam
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ProjectName { get; set; }
        public int? Year { get; set; }
        public int? Members { get; set; }
        public bool? IsActive { get; set; }
        public int AccountId { get; set; }
    }
}
