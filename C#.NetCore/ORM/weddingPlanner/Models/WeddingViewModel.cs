using System;
using System.ComponentModel.DataAnnotations;
 
namespace weddingPlanner.Models
{
    public class NewWedding : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string WedOne {get;set;}
        [Required]
        [MinLength(2)]
        public string WedTwo {get;set;}
        [DateValid(ErrorMessage="You must enter a future date!")]
        public DateTime Date { get; set; }
        [Required]
        [MinLength(6)]
        public string Address {get;set;}
         public class DateValidAttribute : ValidationAttribute
        {
            public override bool IsValid(object userdate)
            {
                return userdate != null && (DateTime)userdate > DateTime.Now;
            }
        }
        
    }

}
