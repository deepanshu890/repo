using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.DAL;
using Company.Services.Models;

namespace Company.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        CompanyRepository rep;
        public UsersController()
        {
            rep = new CompanyRepository();
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<DAL.Models.AddressUsers> products = new List<DAL.Models.AddressUsers>();
            try
            {
                products = rep.GetUsersDetails();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public JsonResult AddUser(User dep)
        {
            bool status = false;
            string message;
            try
            {
                DAL.Models.Address p = new DAL.Models.Address();
                p.AddressLine = dep.AddressLine;
                p.City = dep.City;
                p.State = dep.State;
                p.Pincode = dep.Pincode;
                
                int id = rep.AddAddress(p);

                DAL.Models.Users e = new DAL.Models.Users();
                e.AddressId = id;
                e.FirstName = dep.FirstName;
                e.LastName = dep.LastName;
                e.EmailId = dep.EmailId;
                e.Gender = dep.Gender;
                e.PhoneNumber = dep.PhoneNumber;
                status = rep.AddUsers(e);

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
        public bool UpdateUserDetails(Models.User emp)
        {
            bool status = false;

            try
            {

                DAL.Models.Users category = new DAL.Models.Users();

                category.UserId = emp.UserId;
                category.FirstName = emp.FirstName;
                category.LastName = emp.LastName;
                category.EmailId = emp.EmailId;
                category.Gender = emp.Gender;
                category.PhoneNumber = emp.PhoneNumber;

               status =  rep.UpdateUser(category);

                DAL.Models.Address e = new DAL.Models.Address();
                e.AddressId = emp.AddressId;
                e.AddressLine = emp.AddressLine;
                e.City = emp.City;
                e.State = emp.State;
                e.Pincode = emp.Pincode;
            
               status =  rep.UpdateAddress(e);

          
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public JsonResult DeleteUser(User u)
        {
            bool status = false;
            

            try
            {
                rep.DeleteAddress(u.AddressId);
               

                status = rep.DeleteUser(u.UserId);
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
