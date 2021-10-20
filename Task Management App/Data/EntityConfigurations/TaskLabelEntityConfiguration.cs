using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class TaskLabelEntityConfiguration : IEntityTypeConfiguration<TaskLabel>
    {
        public void Configure(EntityTypeBuilder<TaskLabel> builder)
        {
            builder
                .HasKey(tl => new { tl.TaskID, tl.LabelID });

            builder
                .HasOne(tl => tl.Task)
                .WithMany(t => t.TaskLabels);
            builder
                .HasOne(tl => tl.Label)
                .WithMany(l => l.TaskLabels);
        }
    }
}
