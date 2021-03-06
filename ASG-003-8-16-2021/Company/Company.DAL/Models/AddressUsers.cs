using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.DAL.Models
{
    public class AddressUsers
    {
        [Key]
        public int UserId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
    }
}
