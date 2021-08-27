using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.Services.Models;
using Company.DAL.Models;

namespace Company.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : Controller
    {
        ICompanyRepository rep;
        public TeamController(ICompanyRepository _rep)
        {
            rep = _rep;
        }

        [HttpGet]
        public async Task<JsonResult> GetAllTeams()
        {
            List<DAL.Models.Team> products = new List<DAL.Models.Team>();
            try
            {
                products = await rep.GetTeam();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public async Task<JsonResult> AddTeam(Models.AccountTeam dep)
        {
            int teamId;
            bool status = false;
            string message;
            try
            {
                DAL.Models.Team p = new DAL.Models.Team();
                p.TeamName = dep.TeamName;
                p.ProjectName = dep.ProjectName;
                decimal d = (decimal)dep.Year;
                p.Year = d;
                byte value1 = (byte)dep.Members;
                p.Members = value1;
                p.IsActive = dep.IsActive;

                teamId = await rep.AddTeam(p);

                DAL.Models.AccountTeam obj = new DAL.Models.AccountTeam();
                obj.TeamId = teamId;
                obj.AccountId = dep.AccountId;
                status = await rep.AddAccountTeam(obj);


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
        public async Task<bool> UpdateTeam(Models.Team dep)
        {
            bool status = false;

            try
            {
                DAL.Models.Team p = new DAL.Models.Team();
                p.TeamId = dep.TeamId;
                p.TeamName = dep.TeamName;
                p.ProjectName = dep.ProjectName;
                p.Year = dep.Year;
                byte value1 = (byte)dep.Members;
                p.Members = value1;
               // p.Members = dep.Members;
                p.IsActive = dep.IsActive;

                status = await rep.UpdateTeam(p);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTeam(Models.Team u)
        {
            bool status = false;
            try
            {
                await rep.DeleteForeignTeam(u.TeamId);
                status = await rep.DeleteTeam(u.TeamId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return Json(status);
        }

        [HttpGet]
        public async Task<JsonResult> GetTeamMembers(int teamId)
        {
            List<DAL.Models.AddressUsers> products = new List<DAL.Models.AddressUsers>();
            try
            {
                products = await rep.getTeamMembers(teamId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public async Task<JsonResult> AddTeamMember(DAL.Models.TeamMembers dep)
        {
            bool status = false;
            string message;
            try
            {           
             
                status = await rep.AddTeamMember(dep);

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

        [HttpGet]
        public async Task<JsonResult> GetTeamUsers()
        {
            List<DAL.Models.TeamMembers> products = new List<DAL.Models.TeamMembers>();
            try
            {
                products = await rep.GetTeamUsers();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }


        [HttpGet]
        public async Task<JsonResult> GetTeamAccounts(int AccountId)
        {
            List<DAL.Models.TeamAccount> products = new List<DAL.Models.TeamAccount>();
            try
            {
                products = await rep.GetTeamAccount(AccountId);
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }


        [HttpGet]
        public async Task<JsonResult> GetTeamOnes(int AccountId)
        {
            List<DAL.Models.TeamAccount> products = new List<DAL.Models.TeamAccount>();
            try
            {
                products = await rep.GetTeamOne(AccountId);
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public async Task<JsonResult> AddAccounts(Account dep)
        {
            bool status = false;
            string message;
            try
            {

                status = await rep.AddAccount(dep);


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
        public async Task<bool> UpdateAccounts(Account emp)
        {
            bool status = false;



            try
            {
                status = await rep.UpdateAccount(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }



        [HttpDelete]
        public async Task<JsonResult> DeleteAccount(int u)
        {
            bool status = false;
            try
            {
                await rep.DeleteForeignAccount(u);
                status = await rep.DeleteAccount(u);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                status = false;
            }
            return Json(status);
        }


        [HttpGet]



        public async Task<JsonResult> GetAccounts()
        {
            List<DAL.Models.Account> products = new List<DAL.Models.Account>();
            try
            {
                products = await rep.GetAccount();
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }
    }
}
