using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ProPlanUserEntityConfiguration : IEntityTypeConfiguration<ProPlanUser>
    {
        public void Configure(EntityTypeBuilder<ProPlanUser> builder)
        {
            builder
                .HasKey(ppu => new { ppu.ProPlanID, ppu.UserID });

            builder
                .Property(ppu => ppu.StartDate)
                .IsRequired();
            builder
                .Property(ppu => ppu.Active)
                .IsRequired();

            builder
                .HasOne(ppu => ppu.ProPlan)
                .WithMany(pp => pp.ProPlanUsers);
        }
    }
}
