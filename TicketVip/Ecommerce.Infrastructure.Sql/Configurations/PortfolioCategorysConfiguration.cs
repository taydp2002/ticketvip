using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Sql.Configurations;

public class PortfolioCategoryConfiguration : IEntityTypeConfiguration<PortfolioCategory>
{
    public void Configure(EntityTypeBuilder<PortfolioCategory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(prop => prop.Name)
            .HasMaxLength(256)
            .IsRequired();

     

        builder.Property(prop => prop.Slug)
            .HasMaxLength(256);

       
    }
}
