using System;
using System.ComponentModel.DataAnnotations;
 
namespace weddingPlanner.Models
{
    public class RegUser : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [MinLength(2)]
        public string LastName {get;set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage="Password must contain at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [CompareAttribute("Password", ErrorMessage="Password and Confirm Password must match!")]
        public string ConfirmPassword {get;set;}
        
    }
    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }

    public class LogReg : BaseEntity
    {
        public RegUser reg {get;set;}
        public LoginUser log {get;set;}
    }
 

}
