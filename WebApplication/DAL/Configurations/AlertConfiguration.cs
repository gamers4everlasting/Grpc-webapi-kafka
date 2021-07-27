using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.DAL.Entities;

namespace WebApplication.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Alert>
    {
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.ToTable($"{nameof(Alert)}s");
            builder.HasKey(x => x.Id);
        }
    }
}