using System;
using System.Collections.Generic;
using System.Text;
using AdventureWorks2019.DAL.Models;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

//Person

        //Person.BuisnessEntity
        public int AddBuisnessEntityId(BusinessEntity e)
        {
            int id = 0;
            BusinessEntity category = new BusinessEntity();
            category.Rowguid = e.Rowguid;
            category.ModifiedDate = e.ModifiedDate;
            //category.ModifiedDate = date;
            try
            {
                context.BusinessEntity.Add(category);
                //context.Add<Categories>(category);
                context.SaveChanges();
                id = (from record in context.BusinessEntity orderby record.BusinessEntityId select record.BusinessEntityId).Last();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                id  = 0;
            }
            return id;
        }


       /* public int AddBusinessId(Guid rowGuid, DateTime date, out int id)
        {
            id = 0;
            int noOfRowsAffected = 0;
            int returnResult = 0;
            SqlParameter prmRowGuid = new SqlParameter("@rowguid", rowGuid);
            SqlParameter prmDate = new SqlParameter("@ModifiedDate", date);
            SqlParameter prmId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            prmId.Direction = System.Data.ParameterDirection.Output;

            SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
            prmReturnResult.Direction = System.Data.ParameterDirection.Output;
            try
            {
                noOfRowsAffected = context.Database
                                .ExecuteSqlRaw("EXEC @ReturnResult = usp_AddBusinessEntityId @rowguid,@ModifiedDate, @Id OUT",
                                               prmReturnResult, prmRowGuid, prmDate, prmId);
                returnResult = Convert.ToInt32(prmReturnResult.Value);

                id = Convert.ToByte(prmId.Value);
            }
            catch (Exception ex)
            {
                id = 0;
                noOfRowsAffected = -1;
                Console.WriteLine(ex.Message);
                returnResult = -99;
            }
            return returnResult;
        }*/

        public int getBuisnessEntityId()
        {
            int id = (from record in context.BusinessEntity orderby record.BusinessEntityId select record.BusinessEntityId).Last();

            return id;
        }
        

        //Person.Person
        public int AddPerson(Person e)
        {
            int id = 0;
            
            id = (from record in context.Person orderby record.BusinessEntityId select record.BusinessEntityId).Last()+1;
            Person category = new Person();
            category.BusinessEntityId = id;
            category.PersonType = e.PersonType;
            category.NameStyle = e.NameStyle;
            category.FirstName = e.FirstName;
            category.LastName = e.LastName;
            category.EmailPromotion = e.EmailPromotion;
            category.Rowguid = e.Rowguid;
            category.ModifiedDate = e.ModifiedDate;
          
            try
            {
                context.Person.Add(category);
                //context.Add<Categories>(category);
                context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                id = 0;
            }
            return id ;
        }

        //Person.EmailAddress
        public bool AddEmail(EmailAddress e)
        {
            int id = 0;
            bool status = false;
            EmailAddress category = new EmailAddress();
            category.BusinessEntityId = e.BusinessEntityId;
            category.EmailAddress1 = e.EmailAddress1;        
            category.Rowguid = e.Rowguid;
            category.ModifiedDate = e.ModifiedDate;
            try
            {
                context.EmailAddress.Add(category);
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

        //Person.Address

        public bool AddAddress(Address e)
        {
            bool status = false;
            Address category = new Address();
            category.AddressLine1 = e.AddressLine1;
            category.City = e.City;
            category.StateProvinceId = e.StateProvinceId;
            category.PostalCode = e.PostalCode;
            category.Rowguid = e.Rowguid;
            category.ModifiedDate = e.ModifiedDate;
            try
            {
                context.Address.Add(category);
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

        public async Task<List<Address>> GetAddressAll()
        {
            Address address = new Address();
            
                var data = await (from category in context.Address
                                 select category).ToListAsync();
                return data;
        }

        //Person.PersonPhone

        public bool AddPhoneDetails(PersonPhone e)
        {
            bool status = false;
            PersonPhone category = new PersonPhone();
            category.BusinessEntityId = e.BusinessEntityId;
            category.PhoneNumber = e.PhoneNumber;
            category.PhoneNumberTypeId = e.PhoneNumberTypeId;
            category.ModifiedDate = e.ModifiedDate;
            try
            {
                context.PersonPhone.Add(category);
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

        public bool UpdateName(Person dep)
        {
            bool status = false;
            Person category = context.Person.Find(dep.BusinessEntityId);
            try
            {
                if (category != null)
                {
                    category.FirstName = dep.FirstName;
                    category.LastName = dep.LastName;
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

        public bool UpdateEmail(EmailAddress dep)
        {
            bool status = false;
            var id1 = (from record in context.EmailAddress
                       where record.BusinessEntityId == dep.BusinessEntityId
                       select record.EmailAddressId).FirstOrDefault();
            EmailAddress category = context.EmailAddress.Find(dep.BusinessEntityId,id1);
            try
            {
                if (category != null)
                {
                    category.EmailAddress1 = dep.EmailAddress1;
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
                    category.AddressLine1 = dep.AddressLine1;
                    category.City = dep.City;
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


        public bool DeletePerson(int businessEntityId)
        {
            Person product = null;
            bool status = false;
            try
            {
                product = context.Person.Find(businessEntityId);
                if (product != null)
                {
                    context.Person.Remove(product);
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

        public void getId(int id)
        {
           
            var id1 = (from record in context.EmailAddress
                     where record.BusinessEntityId == id
                      select record.EmailAddressId).FirstOrDefault();
            Console.WriteLine(id1);
        }

        public bool DeleteEmail(int businessEntityId)
        {
            EmailAddress product = null;
            bool status = false;
            var id = (from record in context.EmailAddress
                     where record.BusinessEntityId == businessEntityId
                     select record.EmailAddressId).First();
            try
            {
                product = context.EmailAddress.Find(businessEntityId, id);
                if (product != null)
                {
                    context.EmailAddress.Remove(product);
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

        public bool DeleteAddess(int addressId)
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
