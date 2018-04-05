using System.ComponentModel.DataAnnotations;
namespace dojoLeague.Models
{
    public abstract class BaseEntity {}
    public class Ninja : BaseEntity
    {
        [Key]
        public int Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [Range(1,11)]
        public int Level { get; set; }

        public Dojo Dojo { get; set; }
        public string Description { get; set; }

        

    }
}
