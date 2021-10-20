using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class BlockEntityConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder
                .HasKey(b => new { b.User1ID, b.User2ID });

            builder
                .HasOne(u => u.User1)
                .WithMany(ut => ut.BlocksByUser)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(u => u.User2)
                .WithMany(ut => ut.BlocksByOthers)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
