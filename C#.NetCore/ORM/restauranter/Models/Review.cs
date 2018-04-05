using System;
using System.ComponentModel.DataAnnotations;
namespace restauranter.Models
{
    public abstract class BaseEntity { }
    public class Review : BaseEntity
    {
        [Key]
        public int RestId { get; set; }
        [Required]
        public string Restaurant { get; set; }
        [Required]
        public string Reviewer { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        [Required]
        [DateValid(ErrorMessage="You must enter a past date time traveller!")]
        public DateTime VisitDate { get; set; }
        [Required]
        public int Star { get; set; }
        public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate < DateTime.Now;
            }
        }

    }

}
