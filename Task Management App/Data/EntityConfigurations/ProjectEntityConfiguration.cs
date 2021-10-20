using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.ID);

            builder
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(p => p.Description)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
