using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingRoom.Persistence.ConfigurationTables
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.RefreshTokens);

            //Set Primary Key

            //Set Property in table
            builder.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(int.MaxValue);

            builder.Property(e => e.Expires)
                .IsRequired();

            builder.Property(e => e.CreatedDate)
                .IsRequired();
            
            builder.Property(e => e.LastModifiedDate);

         
        }
    }
}
