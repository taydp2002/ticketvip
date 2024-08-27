using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Sql.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(prop => prop.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Description)
                .HasMaxLength(800)
                .IsRequired();

            builder.Property(prop => prop.Phone).IsRequired()
                .HasMaxLength(15);

            builder.Property(prop => prop.Email)
                .IsRequired().HasMaxLength(200); ;

        }
    
    }
}
