using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks2019.DAL;
using AdventureWorks2019.DAL.Models;
namespace AdventureWorks2019.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HumanResourceController : Controller
    {
        AdventureWorks2019Repository repo;
        public HumanResourceController()
        {
            repo = new AdventureWorks2019Repository();
        }


//Department Section
        [HttpGet]
        public JsonResult GetAllDepartment()
        {
            List<Department> products = new List<Department>();
            try
            {
                products = repo.GetDepartment();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public JsonResult AddDepartment(Department dep)
        {
            bool status = false;
            string message;
            try
            {
                status = repo.AddDepartment(dep);
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
        public bool UpdateDepartment(Models.Department dep)
        {
            bool status = false;

            try
            {

                Department prodObj = new Department();
                prodObj.DepartmentId = dep.DepartmentId;
                prodObj.Name = dep.Name;
                prodObj.GroupName = dep.GroupName;
                prodObj.ModifiedDate = dep.ModifiedDate;
                status = repo.UpdateDepartment(prodObj);
            }

            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public JsonResult DeleteDepartment(short departmentId)
        {
            bool status = false;

            try
            {
                status = repo.DeleteDepartment(departmentId);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }

        //Employee Section

        [HttpGet]
        public JsonResult GetAllEmployee()
        {
            List<Employee> products = new List<Employee>();
            try
            {
                products = repo.GetEmployee();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }

        [HttpPost]
        public JsonResult AddEmployee(Employee emp)
        {
            bool status = false;
            string message;
            try
            {
                status = repo.AddEmployee(emp);
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
        public bool UpdateEmployee(Models.Employee emp)
        {
            bool status = false;

            try
            {

                Employee category = new Employee();
               
                category.BusinessEntityId = emp.BusinessEntityId;
                category.NationalIdnumber = emp.NationalIdnumber;
                category.LoginId = emp.LoginId;
                category.OrganizationLevel = emp.OrganizationLevel;
                category.JobTitle = emp.JobTitle;
                category.BirthDate = emp.BirthDate;
                category.MaritalStatus = emp.MaritalStatus;
                category.Gender = emp.Gender;
                category.HireDate = emp.HireDate;
                category.SalariedFlag = emp.SalariedFlag;
                category.VacationHours = emp.VacationHours;
                category.SickLeaveHours = emp.SickLeaveHours;
                category.CurrentFlag = emp.CurrentFlag;
                category.Rowguid = emp.Rowguid;
                category.ModifiedDate = emp.ModifiedDate;
                status = repo.UpdateEmployee(category);
            }

            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int businessEntityID)
        {
            bool status = false;

            try
            {
                status = repo.DeleteEmployee(businessEntityID);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }

        [HttpGet]

        public JsonResult getUserDetails()
        {
            List<UserDetail> products = new List<UserDetail>();
            try
            {
                products = repo.GetUserDetails();
            }
            catch (Exception ex)
            {
                products = null;
            }
            return Json(products);
        }


    }
}
