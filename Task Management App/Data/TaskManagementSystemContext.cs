using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Task_Management_System.Models;

namespace Task_Management_System.Data
{
    public class TaskManagementSystemContext : DbContext
    {
        public TaskManagementSystemContext(DbContextOptions<TaskManagementSystemContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer(@"Data Source=DESKTOP-TLQCK5S\SQLTEST;Initial Catalog=TaskManagementSystemDB;Trusted_Connection=True");
        //}

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProPlan> ProPlans { get; set; }
        public DbSet<ProUser> ProUsers { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskRole> TaskRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(e => e.UserImage)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserTask>()
                .HasKey(ut => new { ut.UserID, ut.TaskID});
            modelBuilder.Entity<UserTask>()
                .HasOne(u => u.User)
                .WithMany(ut => ut.UserTasks);
            modelBuilder.Entity<UserTask>()
                .HasOne(t => t.Task)
                .WithMany(ut => ut.UserTasks);

            modelBuilder.Entity<UserTask>()
                .HasOne(tr => tr.TaskRole)
                .WithMany(ut => ut.UserTasks)
                .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<TaskRole>()
            //    .HasMany(ut => ut.UserTasks)
            //    .WithOne(tr => tr.TaskRole)
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
