using HomiePages.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomiePages.Infrastructure.Persistence.Configurations
{
    public class BaseContainerConfigration : IEntityTypeConfiguration<BaseContainer>
    {
        public void Configure(EntityTypeBuilder<BaseContainer> builder)
        {
            builder.HasOne(e => e.Layout);
        }
    }
}