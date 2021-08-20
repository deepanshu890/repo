using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.Services.Models;


namespace Company.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : Controller
    {
        CompanyRepository rep;
        public TeamController()
        {
            rep = new CompanyRepository();
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
        public async Task<JsonResult> AddTeam(Team dep)
        {
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

                status = await rep.AddTeam(p);

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
        public async Task<bool> UpdateTeam(Team dep)
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
        public async Task<JsonResult> DeleteTeam(Team u)
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
        public async Task<JsonResult> GetTeamMembers(int t)
        {
            List<DAL.Models.AddressUsers> products = new List<DAL.Models.AddressUsers>();
            try
            {
                products = await rep.getTeamMembers(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                products = null;
            }
            return Json(products);
        }

    }
}
