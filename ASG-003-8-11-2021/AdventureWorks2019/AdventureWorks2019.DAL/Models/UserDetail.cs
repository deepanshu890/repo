using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdventureWorks2019.DAL.Models
{
    public class UserDetail
    {
        [Key]
        public int BusinessEntityId { get; set; }
        public int AddressId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

       
        public string AddressLine1 { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
