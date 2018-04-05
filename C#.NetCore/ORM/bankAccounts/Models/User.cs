using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace bankAccounts.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Changes {get; set;}
        public User()
        {
            Changes = new List<Transaction>();
            Balance = 0.0;
        }
    }

}
