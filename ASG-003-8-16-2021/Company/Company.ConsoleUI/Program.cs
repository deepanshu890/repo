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
            u = rep.getTeamMembers(502);
            foreach(var i in u)
            {
                Console.WriteLine(i.UserId);
                Console.WriteLine(i.FirstName);
            }
            }
        }
    }

