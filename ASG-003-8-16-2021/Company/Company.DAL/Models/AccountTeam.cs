using System;
using System.Collections.Generic;
using System.Text;

namespace Company.DAL.Models
{
    public partial class AccountTeam
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Account Account { get; set; }
    }
}
