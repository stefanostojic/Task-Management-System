using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class UserTaskEntityConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder
                .HasKey(ut => new { ut.UserID, ut.TaskID });

            builder
                .Property(ut => ut.AssignmentDate)
                .IsRequired();
            builder
                .Property(ut => ut.EstimatedEndDate)
                .IsRequired();
            builder
                .Property(ut => ut.ActualEndDate)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithMany(ut => ut.UserTasks);
            builder
                .HasOne(t => t.Task)
                .WithMany(ut => ut.UserTasks);

            builder
                .HasOne(tr => tr.TaskRole)
                .WithMany(ut => ut.UserTasks)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
