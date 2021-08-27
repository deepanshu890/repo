using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        ICompanyRepository rep;
        public AccountController(ICompanyRepository _rep)
        {
            rep = _rep;
        }

        [HttpGet]
        public async Task<JsonResult> GetAccountUsers(int AccountId)
        {
            List<DAL.Models.AddressUsers> products = new List<DAL.Models.AddressUsers>();
            try
            {
                products = await rep.getAccountUsers(AccountId);
            }
            catch (Exception)
            {
                products = null;
            }
            return Json(products);
        }
    }
}
