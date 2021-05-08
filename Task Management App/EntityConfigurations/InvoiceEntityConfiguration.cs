using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .HasKey(i => i.ID);

            builder
                .Property(i => i.PeriodStartDate)
                .IsRequired();
            builder
                .Property(i => i.PeriodEndDate)
                .IsRequired();
            builder
                .Property(i => i.Amount)
                .IsRequired();
            builder
                .Property(i => i.Paid)
                .IsRequired();

            builder
                .HasOne(i => i.ProPlanUser)
                .WithMany(ppu => ppu.Invoices)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
