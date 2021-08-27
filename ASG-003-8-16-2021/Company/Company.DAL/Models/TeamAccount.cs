using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Company.DAL.Models
{
    public class TeamAccount
    {
        [Key]
        
        public int AccountId { get; set; }
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
     


    }
}
