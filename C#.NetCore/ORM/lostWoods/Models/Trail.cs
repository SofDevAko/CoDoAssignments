using System.ComponentModel.DataAnnotations;
namespace lostWoods.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public float Elevation { get; set; }

        [Required]
        public float Lon { get; set; }

        [Required]
        public float Lat { get; set; }
    }
}
