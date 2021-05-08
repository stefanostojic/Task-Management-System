using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class UserProjectEntityConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder
                .HasKey(up => new { up.UserID, up.ProjectID });

            builder
                .Property(up => up.Accepted)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects);
            builder
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects);
            builder
                .HasOne(up => up.ProjectRole)
                .WithMany(pr => pr.UserProjects);
        }
    }
}
