using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.Configurations
{
    public class SymbolConfiguration : IEntityTypeConfiguration<Symbol>
    {
        public void Configure(EntityTypeBuilder<Symbol> builder)
        {
            builder.ToTable($"{nameof(Symbol)}s");
            builder.HasKey(x => x.Id);
        }
    }
}