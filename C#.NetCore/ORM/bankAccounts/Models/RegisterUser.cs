using System;
using System.ComponentModel.DataAnnotations;
 
namespace bankAccounts.Models
{
    public abstract class BaseEntity{}
    public class RegUser : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage="Please enter two or more characters for User Name!")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }

    
 

}
