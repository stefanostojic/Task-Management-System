using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class TaskRoleEntityConfiguration : IEntityTypeConfiguration<TaskRole>
    {
        public void Configure(EntityTypeBuilder<TaskRole> builder)
        {
            builder
                .HasKey(tr => tr.ID);

            builder
                .Property(tr => tr.Name)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
