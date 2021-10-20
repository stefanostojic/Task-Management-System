using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ProPlanEntityConfiguration : IEntityTypeConfiguration<ProPlan>
    {
        public void Configure(EntityTypeBuilder<ProPlan> builder)
        {
            builder
                .HasKey(pp => pp.ID);

            builder
                .Property(pp => pp.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(pp => pp.Price)
                .IsRequired();
            builder
                .Property(pp => pp.Active)
                .IsRequired();
        }
    }
}
