using System;
using System.Collections.Generic;
using System.Text;
using Company.DAL.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL
{
    public class CompanyRepository
    {
        CompanyDBContext context;
        public CompanyRepository()
        {
            context = new CompanyDBContext();
        }

        public async Task<List<Users>> GetUsers()
        {

            var u = await (from category in context.Users
                     select category).ToListAsync();
            return u;
        }

        public async Task<List<AddressUsers>> GetUsersDetails()
        {

            //await Task.Delay(3000);
           // List<AddressUsers> result1 = null;
              return await(from i in context.Address
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
                      }).ToListAsync();
            //return result1;
        }

        public async Task<int> AddAddress(Address e)
        {
           // await Task.Delay(3000);
            int status = 0;
            Address category = new Address();
            category.AddressLine = e.AddressLine;
            category.City = e.City;
            category.State = e.State;
            category.Pincode = e.Pincode;
            
            try
            {
               await context.Address.AddAsync(category);
               await context.SaveChangesAsync();
                status = (from record in context.Address orderby record.AddressId select record.AddressId).Last();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = 0;
            }
            return status;
        }

        public async Task<bool> AddUsers(Users e)
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
                await context.Users.AddAsync(category);
                await context.SaveChangesAsync();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return status;
        }

        public async Task<bool> UpdateUser(Users dep)
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
                 
                    await context.SaveChangesAsync();
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

        public async Task<bool> UpdateAddress(Address dep)
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
            

                   await context.SaveChangesAsync();
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

        public async Task<bool> DeleteUser(int userId)
        {
            Users product = null;
            bool status = false;
            try
            {
                product = context.Users.Find(userId);
                if (product != null)
                {
                    context.Users.Remove(product);
                    await context.SaveChangesAsync();
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

        public async Task<bool> DeleteAddress(int addressId)
        {
            Address product = null;
            bool status = false;
            try
            {
                product = context.Address.Find(addressId);
                if (product != null)
                {
                    context.Address.Remove(product);
                    await context.SaveChangesAsync();
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

        public async Task<bool> DeleteForeignUser(int userId)
        {
            TeamMembers product = null;
            List<TeamMembers> t = new List<TeamMembers>();
           var t1 = (from i in context.TeamMembers
                 where i.UserId == userId
                 select i.Sno).ToList();
            bool status = false;
            try
            {
                foreach(var i in t1)
                {
                    product = context.TeamMembers.Find(i);
                    if (product != null)
                    {
                        context.TeamMembers.Remove(product);
                        await context.SaveChangesAsync();
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
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

        public async Task<bool> AddTeam(Team e)
        {
            bool status = false;
            Team category = new Team();
            category.TeamName = e.TeamName;
            category.ProjectName = e.ProjectName;
            category.Year = e.Year;
            category.Members = e.Members;
            category.IsActive = e.IsActive;

            try
            {
                await context.Team.AddAsync(category);
                await context.SaveChangesAsync ();
                //status = (from record in context.Address orderby record.AddressId select record.AddressId).Last();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public async Task<bool> UpdateTeam(Team dep)
        {
            bool status = false;
            Team category = context.Team.Find(dep.TeamId);
            try
            {
                if (category != null)
                {
                    category.TeamName = dep.TeamName;
                    category.ProjectName = dep.ProjectName;
                    category.Year = dep.Year;
                    category.Members = dep.Members;
                    category.IsActive = dep.IsActive;

                    await context.SaveChangesAsync ();
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

        public async Task<List<Team>> GetTeam()
        {

            var u = await (from category in context.Team
                     select category).ToListAsync();
            return u;
        }

        public async Task<bool> DeleteTeam(int teamId)
        {
            Team product = null;
            bool status = false;
            try
            {
                product = context.Team.Find(teamId);
                if (product != null)
                {
                    context.Team.Remove(product);
                    await context.SaveChangesAsync();
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

        public async Task<bool> DeleteForeignTeam(int teamId)
        {
            TeamMembers product = null;
            List<TeamMembers> t = new List<TeamMembers>();
            var t1 = (from i in context.TeamMembers
                      where i.TeamId == teamId
                      select i.Sno).ToList();
            bool status = false;
            try
            {
                foreach (var i in t1)
                {
                    product = context.TeamMembers.Find(i);
                    if (product != null)
                    {
                        context.TeamMembers.Remove(product);
                        await context.SaveChangesAsync();
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
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

        public async Task<List<AddressUsers>> getTeamMembers(int teamId)
        {
            return await (from i in context.Team
                    where i.TeamId == teamId
                    join s in context.TeamMembers on i.TeamId equals s.TeamId
                    join u in context.Users on s.UserId equals u.UserId
                    join a in context.Address on u.AddressId equals a.AddressId
                    
                    select new AddressUsers
                    {
                        AddressId = a.AddressId,
                        AddressLine = a.AddressLine,
                        City = a.City,
                        Pincode = a.Pincode,
                        State = a.State,
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        EmailId = u.EmailId,
                        Gender = u.Gender,
                        PhoneNumber = u.PhoneNumber
                    }).ToListAsync();
        }
    }
}

