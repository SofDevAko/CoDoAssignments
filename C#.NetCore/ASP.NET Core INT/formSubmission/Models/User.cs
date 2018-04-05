using System.ComponentModel.DataAnnotations;


namespace formSubmission.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage="Please enter First Name")]
        [MinLength(4, ErrorMessage="First Name should be more than 4 characters")]
        public string First_Name { get; set; }
        [Required(ErrorMessage="Please enter Last Name")]
        [MinLength(4, ErrorMessage="Last Name should be more than 4 characters")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage="Please enter Age")]
        [Range(1,1000, ErrorMessage="Age should be positive")]
        public int Age { get; set; }
        [Required(ErrorMessage="Please enter Email address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage="Please enter Password")]
        [MinLength(8, ErrorMessage="Password should be more than 8 characters")]
        public string Password { get; set; }
    }

    public abstract class BaseEntity
    {
    }
}