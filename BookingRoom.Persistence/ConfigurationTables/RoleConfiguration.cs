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
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Roles);

            //Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Foreign Key
            //builder.HasMany(e => e.UserRoles)
            //      .WithOne()
            //      .HasForeignKey(ut => ut.RoleId)
            //      .IsRequired();

            //Set Property in table
            builder.Property(e => e.RoleName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.RoleDescription)
                  .IsRequired(false)
                  .HasMaxLength(200);
           
        }
    }
}
