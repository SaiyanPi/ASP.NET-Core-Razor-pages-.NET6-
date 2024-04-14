using Microsoft.EntityFrameworkCore;
using ZappaWeb.Model;

namespace ZappaWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }
        public DbSet<Category> Categories { get; set; } //'Categories' is the table name
    }
}
