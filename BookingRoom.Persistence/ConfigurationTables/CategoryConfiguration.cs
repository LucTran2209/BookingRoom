using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingRoom.Persistence.ConfigurationTables
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Categories);

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property in table
            builder.Property(x => x.CategoryName)
                .HasDefaultValue(null)
                .IsRequired();
        }
    }
}
