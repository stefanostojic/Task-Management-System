using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(15)
                .IsRequired();
            builder
                .Property(u => u.LastName)
                .HasMaxLength(15)
                .IsRequired();
            //builder
            //    .Property(u => u.Email)
            //    .HasMaxLength(30)
            //    .IsRequired();
            //builder
            //    .Property(u => u.Password)
            //    .IsRequired();

            //builder
            //    .HasOne(u => u.Image)
            //    .WithOne(u => u.User)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(ur => ur.UserRole)
                .WithMany(u => u.Users)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
