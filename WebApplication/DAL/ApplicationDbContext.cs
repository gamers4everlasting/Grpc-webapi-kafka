using Microsoft.EntityFrameworkCore;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL
{
    public class ApplicationDbContext : DbContext {
        
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) 
            : base (options) 
        { }
        
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
    }
}