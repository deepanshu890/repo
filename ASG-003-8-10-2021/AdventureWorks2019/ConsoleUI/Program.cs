using System;
using AdventureWorks2019.DAL;
using AdventureWorks2019.DAL.Models;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          
            AdventureWorks2019Repository rep = new AdventureWorks2019Repository();
           


            var result = rep.GetUserDetails();
            if (result.Count==0)
            {
                Console.WriteLine("No products available under the given category!");
            }
            else
            {
                foreach (var product in result)
                {
                    Console.WriteLine("{0, -12}{1, -30}{2}", product.FirstName, product.LastName, product.AddressLine1);
                }
            }
        }
    }
}
