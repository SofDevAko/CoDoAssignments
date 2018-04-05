using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class RESTContext : DbContext
    {
        public RESTContext(DbContextOptions<RESTContext> options) : base(options) { }
        public DbSet<Review> reviews {get; set;}
    }
}
