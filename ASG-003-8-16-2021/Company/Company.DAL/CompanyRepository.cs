using System;
using System.Collections.Generic;
using System.Text;
using Company.DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace Company.DAL
{
    public class CompanyRepository
    {
        CompanyDBContext context;
        public CompanyRepository()
        {
            context = new CompanyDBContext();
        }

        public List<Users> GetUsers()
        {

            var u = (from category in context.Users
                     select category).ToList();
            return u;
        }

        public List<AddressUsers> GetUsersDetails()
        {
            

           // List<AddressUsers> result1 = null;
              return (from i in context.Address
                      join s in context.Users on i.AddressId equals s.AddressId
                      select new AddressUsers
                      {
                         AddressId = i.AddressId,
                         AddressLine =  i.AddressLine,
                         City =  i.City,
                          Pincode = i.Pincode,
                         State =  i.State,
                         UserId =  s.UserId,
                         FirstName =  s.FirstName,
                          LastName = s.LastName,
                          EmailId = s.EmailId,
                          Gender = s.Gender,
                          PhoneNumber  = s.PhoneNumber
                      }).ToList();
            //return result1;
        }

        public int AddAddress(Address e)
        {
            int status = 0;
            Address category = new Address();
            category.AddressLine = e.AddressLine;
            category.City = e.City;
            category.State = e.State;
            category.Pincode = e.Pincode;
            
            try
            {
                context.Address.Add(category);
                context.SaveChanges();
                status = (from record in context.Address orderby record.AddressId select record.AddressId).Last();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 0;
            }
            return status;
        }

        public bool AddUsers(Users e)
        {
            int id = 0;
            bool status = false;
            Users category = new Users();
            category.AddressId = e.AddressId;
            category.FirstName = e.FirstName;
            category.LastName = e.LastName;
            category.EmailId = e.EmailId;
            category.Gender = e.Gender;
            category.PhoneNumber = e.PhoneNumber;
            try
            {
                context.Users.Add(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return status;
        }

        public bool UpdateUser(Users dep)
        {
            bool status = false;
            Users category = context.Users.Find(dep.UserId);
            try
            {
                if (category != null)
                {
                    category.FirstName = dep.FirstName;
                    category.LastName = dep.LastName;
                    category.EmailId = dep.EmailId;
                    category.Gender = dep.Gender;
                    category.PhoneNumber = dep.PhoneNumber;
                 
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        public bool UpdateAddress(Address dep)
        {
            bool status = false;
            Address category = context.Address.Find(dep.AddressId);
            try
            {
                if (category != null)
                {
                    category.AddressLine = dep.AddressLine;
                    category.City = dep.City;
                    category.State = dep.State;
                    category.Pincode = dep.Pincode;
            

                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        public bool DeleteUser(int userId)
        {
            Users product = null;
            bool status = false;
            try
            {
                product = context.Users.Find(userId);
                if (product != null)
                {
                    context.Users.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return status;
        }

        public bool DeleteAddress(int addressId)
        {
            Address product = null;
            bool status = false;
            try
            {
                product = context.Address.Find(addressId);
                if (product != null)
                {
                    context.Address.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return status;
        }



    }
}

