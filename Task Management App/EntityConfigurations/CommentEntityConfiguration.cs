using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(c => c.ID);

            builder
                .Property(c => c.Text)
                .HasMaxLength(300)
                .IsRequired();
            builder
                .Property(c => c.PostedOnDate)
                .IsRequired();

            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(c => c.Task)
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
