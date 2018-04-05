using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
{
    public class Wedding : BaseEntity
    {
        [Key]
        public int WedId {get;set;}
        public int User_Id {get;set;}
        public string WedOne {get;set;}
        public string WedTwo {get;set;}
        public DateTime Date {get;set;}
        public string Address {get;set;}
        public List<Guest> GuestList {get;set;}

        public Wedding()
        {
            List<Guest> GuestList = new List<Guest>();
        }
        
    }
}
