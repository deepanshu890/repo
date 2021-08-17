using System;
using System.Collections.Generic;

namespace Company.DAL.Models
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<Users>();
        }

        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
