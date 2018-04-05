using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public List<Guest> WedList {get;set;}

        public User()
        {
            List<Guest> WedList = new List<Guest>();
        }
        
    }
}
