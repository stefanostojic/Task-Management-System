using Microsoft.EntityFrameworkCore;
using Task_Management_System.EntityConfigurations;
using Task_Management_System.Models;

namespace Task_Management_System.Data
{
    public class TaskManagementSystemContext : DbContext
    {
        public TaskManagementSystemContext(DbContextOptions<TaskManagementSystemContext> options) : base(options)
        {
        }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ProPlan> ProPlans { get; set; }
        public DbSet<ProPlanUser> ProPlanUsers { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskLabel> TaskLabes { get; set; }
        public DbSet<TaskRole> TaskRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlockEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LabelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProPlanEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProPlanUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubtaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskLabelEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserTaskEntityConfiguration());
        }
    }
}
