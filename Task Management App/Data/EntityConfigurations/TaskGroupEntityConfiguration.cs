using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class TaskGroupEntityConfiguration : IEntityTypeConfiguration<TaskGroup>
    {
        public void Configure(EntityTypeBuilder<TaskGroup> builder)
        {
            builder
                .HasKey(tg => tg.ID);

            builder
                .Property(tg => tg.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(tg => tg.Description)
                .HasMaxLength(150)
                .IsRequired();

            builder
                .HasOne(tg => tg.Project)
                .WithMany(p => p.TaskGroups);
        }
    }
}
