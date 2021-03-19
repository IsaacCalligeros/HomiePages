using HomiePages.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomiePages.Infrastructure.Persistence.Configurations
{
    public class PortfolioConfigration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasMany(e => e.Equities);
        }
    }
}