using System;
using System.Collections.Generic;
using AdventureWorks2019.DAL;
using AdventureWorks2019.DAL.Models;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
          
           AdventureWorks2019Repository rep = new AdventureWorks2019Repository();
             Guid x = new Guid("1EB6C052-A007-4052-84A0-59D23705027A");
             DateTime firstDate = new DateTime(2007, 11, 22);
            /*int id = 0;
             BusinessEntity b = new BusinessEntity();
             b.ModifiedDate = firstDate;
             b.Rowguid = x;*/
            /*var result = rep.AddBusinessId(x, firstDate, out id);
            //Console.WriteLine(result);
            if (result > 0)
                Console.WriteLine(id);
            else
                Console.WriteLine("error");*/

            /*  id = rep.AddBuisnessEntityId(b);
              Console.WriteLine(id);
  */
            /*     int id = rep.getId();
                 Console.WriteLine(id);*/

            /*            var query = rep.GetAddressAll();

                        List<Address> deb = query.Result;

                        foreach (var i in deb)
                        {
                            Console.WriteLine(i.AddressLine1);
                        }
            */

            Person p = new Person();
            p.PersonType = "EM";
            p.NameStyle = false;
            p.FirstName = "asd";
            p.LastName = "gty";
            p.EmailPromotion = 0;
           /* Guid ex = new Guid("CD0B82D0-3509-4497-A65F-A68E75EE26CB");
            DateTime firstDate = new DateTime(2012, 12, 10);*/
            p.Rowguid = x;
            p.ModifiedDate = firstDate;
            int id = rep.AddPerson(p);



            Console.WriteLine(id);

        }
    }
}
