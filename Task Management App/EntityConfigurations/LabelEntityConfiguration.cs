using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class LabelEntityConfiguration : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder
                .HasKey(l => l.ID);
            builder
                .HasAlternateKey(l => l.Name);

            builder
                .Property(l => l.Name)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
