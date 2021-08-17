using System;
using Company.DAL.Models;
using Company.DAL;
using System.Collections.Generic;

namespace Company.ConsoleUI
{
   public class Program
    {
        static void Main(string[] args)
        {
            CompanyRepository rep = new CompanyRepository();
            List<AddressUsers> u;
            var z = rep.GetUsersDetails();
            foreach(var i in z)
            {
                Console.WriteLine(i.FirstName);
                Console.WriteLine(i.AddressLine);
            }
        }
    }
}
