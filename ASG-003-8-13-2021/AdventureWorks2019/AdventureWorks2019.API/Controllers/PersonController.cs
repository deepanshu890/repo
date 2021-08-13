using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks2019.API.Models;
using AdventureWorks2019.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks2019.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        AdventureWorks2019Repository repo;
        public PersonController()
        {
            repo = new AdventureWorks2019Repository();
        }

        [HttpPost]
        public JsonResult AddPerson(Person dep)
        {
            bool status = false;
            string message;
            try
            {
                DAL.Models.Person p = new DAL.Models.Person();
                p.PersonType = dep.PersonType;
                p.NameStyle = dep.NameStyle;
                p.FirstName = dep.FirstName;
                p.LastName = dep.LastName;
                p.EmailPromotion = dep.EmailPromotion;
                p.ModifiedDate = dep.ModifiedDate;
                p.Rowguid = dep.Rowguid;
                int id = repo.AddPerson(p);

                DAL.Models.EmailAddress e = new DAL.Models.EmailAddress();
                e.BusinessEntityId = id;
                e.EmailAddress1 = dep.EmailAddress1;
                e.Rowguid = dep.Rowguid;
                e.ModifiedDate = dep.ModifiedDate;
                repo.AddEmail(e);

                DAL.Models.Address a = new DAL.Models.Address();
                a.AddressLine1 = dep.AddressLine1;
                a.City = dep.City;
                a.StateProvinceId = dep.StateProvinceId;
                a.PostalCode = dep.PostalCode;
                a.Rowguid = dep.Rowguid;
                a.ModifiedDate = dep.ModifiedDate;

                status = repo.AddAddress(a);


                if (status)
                    message = "Successful addition operation";
                else
                    message = "Unsuccessful addition operation!";
            }
            catch (Exception)
            {
                message = "Some error occured, please try again!";
            }
            return Json(message);
        }

        [HttpPut]
        public bool UpdateUserDetails(Models.Person emp)
        {
            bool status = false;

            try
            {

                DAL.Models.Person category = new DAL.Models.Person();

                category.BusinessEntityId = emp.BusinessEntityId;
                category.FirstName = emp.FirstName;
                category.LastName = emp.LastName;

                repo.UpdateName(category);

                DAL.Models.EmailAddress e = new DAL.Models.EmailAddress();
                e.BusinessEntityId = emp.BusinessEntityId;
                e.EmailAddress1 = emp.EmailAddress1;
                repo.UpdateEmail(e);

                DAL.Models.Address a = new DAL.Models.Address();
                a.AddressId = emp.AddressId;
                a.AddressLine1 = emp.AddressLine1;
                a.City = emp.City;
                status = repo.UpdateAddress(a);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public JsonResult DeleteUser(int businessEntityId, int addressId)
        {
            bool status = false;

            try
            {
                repo.DeleteEmail(businessEntityId);
                repo.DeletePerson(businessEntityId);
                
                status = repo.DeleteAddess(addressId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return Json(status);
        }
    }
}
