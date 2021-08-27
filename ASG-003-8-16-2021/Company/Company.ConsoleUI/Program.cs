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
            SuperUsers s = new SuperUsers();
            s.EmailId = "Deepanshu@email.com";
            s.Password = "deepanshu@123";
            Console.WriteLine(rep.ValidateCredentials(s));

        }
    }
}

