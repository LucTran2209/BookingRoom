using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingRoom.Persistence.ConfigurationTables
{
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Products);

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property in table
            builder.Property(x => x.ProductName)
                .HasDefaultValue(null)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasDefaultValue(null)
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasDefaultValue(null)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasDefaultValue(0);
        }
    }
}
