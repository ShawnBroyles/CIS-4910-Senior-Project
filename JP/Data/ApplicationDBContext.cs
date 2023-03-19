using JP.Models;
using Microsoft.EntityFrameworkCore;

namespace JP.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> account {get; set;}
        public DbSet<Product> product { get; set; }

    }

}
