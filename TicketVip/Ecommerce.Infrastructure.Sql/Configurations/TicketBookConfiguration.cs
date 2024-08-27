using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Sql.Configurations;

public class TicketBookConfiguration : IEntityTypeConfiguration<TicketBook>
{
    public void Configure(EntityTypeBuilder<TicketBook> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(prop => prop.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(prop => prop.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(prop => prop.Phone)
            .HasMaxLength(15).IsRequired();

        builder.Property(prop => prop.DoiTac)
          .HasMaxLength(100).IsRequired(false);

        builder.Property(prop => prop.MaDonHang)
        .HasMaxLength(200).IsRequired(false);

        builder.Property(prop => prop.SanphamDichvu)
        .HasMaxLength(500).IsRequired(false);
        builder.Property(prop => prop.SanphamDichvu)
       .HasMaxLength(200).IsRequired(false);
        builder.Property(prop => prop.Email)
       .HasMaxLength(100).IsRequired(false);



    }
}
