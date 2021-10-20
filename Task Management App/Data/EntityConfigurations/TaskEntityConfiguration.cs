using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasKey(t => t.ID);

            builder
                .Property(t => t.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder
                .Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder
                .Property(t => t.Finished)
                .HasDefaultValue(false)
                .IsRequired();
            builder
                .Property(t => t.DueDate)
                .IsRequired();

            builder
                .HasOne(tg => tg.TaskGroup)
                .WithMany(t => t.Tasks)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
