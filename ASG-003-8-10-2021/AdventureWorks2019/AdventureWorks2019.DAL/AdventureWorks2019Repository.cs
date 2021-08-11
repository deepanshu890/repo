using System;
using System.Collections.Generic;
using System.Text;
using AdventureWorks2019.DAL.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks2019.DAL
{
    public class AdventureWorks2019Repository
    {
        AdventureWorks2019Context context;
        public AdventureWorks2019Repository()
        {
            context = new AdventureWorks2019Context();
        }

        public List<Address> GetAllAddress()
        {
            var addressList = (from category in context.Address
                                  orderby category.AddressId
                                  select category).ToList();
            try
            {
                
                return addressList;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return addressList;
        }

        public bool AddCurrency(string currencyCode, string currencyName, DateTime date )
        {
            bool status = false;
            Currency category = new Currency();
            category.CurrencyCode = currencyCode;
            category.Name = currencyName;
            category.ModifiedDate = date;
            try
            {
                context.Currency.Add(category);
                //context.Add<Categories>(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public List<Person> GetAllPersonDetails()
        {
            var detailList = (from detail in context.Person
                               
                               select detail).ToList();
            try
            {

                return detailList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return detailList;
        }

//HUMAN RESOURCE
    //Department Section
        public List<Department> GetDepartment()
        {
            var departmentList = (from category in context.Department
                               select category).ToList();
            try
            {

                return departmentList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return departmentList;
        }

        public bool AddDepartment(Department dep)
        {
            bool status = false;
            Department category = new Department();
            category.Name = dep.Name;
            category.GroupName = dep.GroupName;
            category.ModifiedDate = dep.ModifiedDate;
            try
            {
                context.Department.Add(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public bool UpdateDepartment(Department dep)
        {
            bool status = false;
            Department category = context.Department.Find(dep.DepartmentId);
            try
            {
                if (category != null)
                {
                    category.Name = dep.Name;
                    category.GroupName = dep.GroupName;
                    category.ModifiedDate = dep.ModifiedDate;
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

        public bool DeleteDepartment(short departmentId)
        {
            Department product = null;
            bool status = false;
            try
            {
                product = context.Department.Find(departmentId);
                if (product != null)
                {
                    context.Department.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //Employee Section
        public List<Employee> GetEmployee()
        {
            var employeeList = (from category in context.Employee
                                  select category).ToList();
            try
            {

                return employeeList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employeeList;
        }

        public bool AddEmployee(Employee emp)
        {
            bool status = false;
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
            
            try
            {
                context.Employee.Add(category);
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

        public bool UpdateEmployee(Employee emp)
        {
            bool status = false;
            Employee category = context.Employee.Find(emp.BusinessEntityId);
            try
            {
                if (category != null)
                {
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

        public bool DeleteEmployee(int businessEntityID)
        {
            Employee product = null;
            bool status = false;
            try
            {
                product = context.Employee.Find(businessEntityID);
                if (product != null)
                {
                    context.Employee.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public List<UserDetail> GetUserDetails()
        {
            List<UserDetail> lstProduct = null;
            try
            {
                
                lstProduct = context.UserDetails.FromSqlRaw("SELECT * FROM ufn_GetUserDetails()").ToList();
                //lstProduct = (from ud in context.UserDetails select ud).Take(1000).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstProduct = null;
            }
            return lstProduct;
        }



    }
}
