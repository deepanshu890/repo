using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks2019.API.Models
{
    public class Person
    {
        public int BusinessEntityId { get; set; }
        public int AddressId { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmailPromotion { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string EmailAddress1 { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }

    }
}
