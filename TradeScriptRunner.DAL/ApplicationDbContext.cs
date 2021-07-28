using Microsoft.EntityFrameworkCore;
using TradeScriptRunner.DAL.Entities;

namespace TradeScriptRunner.DAL
{
    public class ApplicationDbContext : DbContext {
        
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) 
            : base (options) 
        { }
        
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
    }
}