using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace dojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        public Dojo()
        {
            ninjateam = new List<Ninja>();
        }
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Info { get; set; }

        public ICollection<Ninja> ninjateam {get; set;}

    }
}
