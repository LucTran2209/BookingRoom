using BookingRoom.Domain.Entities;
using BookingRoom.Persistence.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoom.Persistence.ConfigurationTables
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.Users);

            // Set Primary Key
            builder.HasKey(x => x.Id);

            // Set Foriegn Key
            builder.HasOne(x => x.refreshToken)
                   .WithOne(x => x.User);

            // Set Property in table
            builder.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(15);

            builder.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(int.MaxValue);

            builder.Property(e => e.DateOfBirth)
                  .IsRequired();           
        }
    }

    internal sealed class UserRolesConfiguration : IEntityTypeConfiguration<UserRoles>
    {
       
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            // Set Table Name
            builder.ToTable(TableNames.UserRoles);

            // Set Primary Key
            builder.HasKey(x => new {x.UserId, x.RoleId});

            // Set Forigen Key

            // Set Property & Foreign Key
            builder.HasOne(ur => ur.User)
                  .WithMany(u => u.UserRoles)
                  .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                  .WithMany(r => r.UserRoles)
                  .HasForeignKey(ur => ur.RoleId);
        }
    }
}
