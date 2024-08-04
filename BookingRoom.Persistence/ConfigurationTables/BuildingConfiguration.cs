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
    public sealed class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Buildings);

            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property in table
            builder.Property(x => x.BuildingName)
                .HasDefaultValue(null)
                .IsRequired();

        }

    }
}
