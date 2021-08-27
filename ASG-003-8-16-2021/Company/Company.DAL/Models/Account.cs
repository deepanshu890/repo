using System;
using System.Collections.Generic;
using System.Text;

namespace Company.DAL.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountTeam = new HashSet<AccountTeam>();
        }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public virtual ICollection<AccountTeam> AccountTeam{ get; set; }
    }
}
