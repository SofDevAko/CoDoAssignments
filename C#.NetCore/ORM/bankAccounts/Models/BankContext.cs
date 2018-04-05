
using Microsoft.EntityFrameworkCore;
 
namespace bankAccounts.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<Transaction> transactions {get; set;}
        public DbSet<User> users {get; set;}
    }
}
