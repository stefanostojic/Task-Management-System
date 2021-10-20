using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ProjectRoleEntityConfiguration : IEntityTypeConfiguration<ProjectRole>
    {
        public void Configure(EntityTypeBuilder<ProjectRole> builder)
        {
            builder
                .HasKey(pr => pr.ID);

            builder
                .Property(pr => pr.Name)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
