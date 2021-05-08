using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(i => i.ID);

            builder
                .Property(i => i.FilePath)
                .IsRequired();

            builder
                .HasOne(i => i.Comment)
                .WithMany(c => c.Images)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(i => i.Task)
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
