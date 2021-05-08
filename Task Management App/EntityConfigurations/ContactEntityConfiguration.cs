using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Management_System.Models;

namespace Task_Management_System.EntityConfigurations
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .HasKey(c => new { c.User1ID, c.User2ID });
            builder
                .HasOne(u => u.User1)
                .WithMany(ut => ut.ContactsByUser)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(u => u.User2)
                .WithMany(ut => ut.ContactsByOthers)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
