using HomiePages.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomiePages.Infrastructure.Persistence.Configurations
{
    public class PortfolioConfigration : IEntityTypeConfiguration<BaseContainer>
    {
        public void Configure(EntityTypeBuilder<BaseContainer> builder)
        {
            builder.HasOne(b => b.Layout);
        }
    }
}