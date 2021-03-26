using Task_Management_System.Models;
using System;
using System.Linq;
using Task_Management_System.Data;

namespace Task_Management_System.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaskManagementSystemContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var userRoles = new UserRole[]
            {
                new UserRole{ID=Guid.Parse("c8ae737c-ed9b-4fee-be6f-9c74ba376ae7"), Name="Administrator"},
                new UserRole{ID=Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0"), Name="NormalUser"},
                new UserRole{ID=Guid.Parse("5a1808ce-43b3-4e8b-9789-271b33b04f43"), Name="ProUser"}
            };
            foreach (UserRole ur in userRoles)
            {
                context.UserRoles.Add(ur);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{ID=Guid.Parse("c68af42e-fd7c-4ebb-a8d1-f714a47f60a7"), FirstName="Stefan", LastName="Ostojic", Email="s.ostojic@email.com", Password="123", UserRoleID=Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0")},
                new User{ID=Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08"), FirstName="Dušan", LastName="Krstić", Email="d.krstic@email.com", Password="123", UserRoleID=Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0")},
                new User{ID=Guid.Parse("008127f1-efcd-4a74-8b26-cef9d4854c0c"), FirstName="Dejan", LastName="Tosenberger", Email="tosenberger@email.com", Password="123", UserRoleID=Guid.Parse("c8ae737c-ed9b-4fee-be6f-9c74ba376ae7")}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}