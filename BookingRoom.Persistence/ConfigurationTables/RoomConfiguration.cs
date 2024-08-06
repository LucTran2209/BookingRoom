using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Persistence.ConfigurationTables
{
    public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Rooms);

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property in table
            builder.Property(x => x.RoomName)
                .HasDefaultValue(null)
                .IsRequired();
        }
    }
}
