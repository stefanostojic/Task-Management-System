using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class SubtaskEntityConfiguration : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder)
        {
            builder
                .HasKey(s => s.ID);

            builder
                .Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(s => s.Finished)
                .IsRequired();

            builder
                .HasOne(s => s.Task)
                .WithMany(t => t.Subtasks)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
