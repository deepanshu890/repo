using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Users
    {
        public Users()
        {
            TeamMembers = new HashSet<TeamMembers>();
        }

        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<TeamMembers> TeamMembers { get; set; }
    }
}
