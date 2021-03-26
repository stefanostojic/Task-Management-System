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
    }
}
