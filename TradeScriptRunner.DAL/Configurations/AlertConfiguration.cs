using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeScriptRunner.DAL.Entities;

namespace TradeScriptRunner.DAL.Configurations
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