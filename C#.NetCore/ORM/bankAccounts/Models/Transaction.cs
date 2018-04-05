using System;
using System.ComponentModel.DataAnnotations;
namespace bankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        [Key]
        public int TransId { get; set; }
        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }
        [Required]
        public double Amount {get;set;}
        public DateTime Date {get;set;}
        
        public User User {get; set;}
    }

}
