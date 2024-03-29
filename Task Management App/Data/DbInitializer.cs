﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Task_Management_System.Models;

namespace Task_Management_System.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TaskManagementSystemContext context, UserManager<User> um, RoleManager<UserRole> rm)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                //return;   // DB has been seeded
            }

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            #region UserRoles
            var userRoles = new UserRole[]
            {
                new UserRole {
                    Id = Guid.Parse("c8ae737c-ed9b-4fee-be6f-9c74ba376ae7"),
                    Name = "Administrator"
                },
                new UserRole {
                    Id = Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0"),
                    Name = "NormalUser"
                },
                new UserRole {
                    Id = Guid.Parse("5a1808ce-43b3-4e8b-9789-271b33b04f43"),
                    Name = "ProUser"
                }
            };
            foreach (UserRole ur in userRoles)
            {
                //context.AppUserRoles.Add(ur);
                rm.CreateAsync(ur).Wait();
            }
            context.SaveChanges();
            #endregion

            #region Images
            var images = new Image[]
            {
                new Image {
                    ID = Guid.Parse("065e4bc3-b0ec-4a5f-9b0d-a9814daa977f"),
                    FilePath = "Sample image file path 1"
                },
                new Image {
                    ID = Guid.Parse("9374a199-a242-44d1-8593-4375985b0b17"),
                    FilePath = "Sample image file path 2"
                }
            };
            foreach (Image i in images)
            {
                context.Images.Add(i);
            }
            context.SaveChanges();
            #endregion
            
            #region Users
            var hasher = new PasswordHasher<User>();
            var users = new User[]
            {
                new User {
                    Id = Guid.Parse("c68af42e-fd7c-4ebb-a8d1-f714a47f60a7"),
                    FirstName = "Stefan",
                    LastName = "Ostojić",
                    UserName = "s.ostojic@gmail.com",
                    Email = "s.ostojic@email.com",
                    Password = "123",
                    UserRoleID = Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0")
                    //,ImageID = Guid.Parse("065e4bc3-b0ec-4a5f-9b0d-a9814daa977f")
                }, // NormalUser
                new User {
                    Id = Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08"),
                    FirstName = "Dušan",
                    LastName = "Krstić",
                    UserName = "d.krstic@email.com",
                    Email = "d.krstic@email.com",
                    Password = "123",
                    UserRoleID = Guid.Parse("56860de3-f338-449c-be26-c946d4cb73b0")
                    //,ImageID = Guid.Parse("9374a199-a242-44d1-8593-4375985b0b17")
                }, // NormalUser
                new User {
                    Id = Guid.Parse("008127f1-efcd-4a74-8b26-cef9d4854c0c"),
                    FirstName = "Dejan",
                    LastName = "Tosenberger",
                    UserName = "d.tosenberger@email.com",
                    Email = "d.tosenberger@email.com",
                    Password = "123",
                    UserRoleID = Guid.Parse("c8ae737c-ed9b-4fee-be6f-9c74ba376ae7")
                    //,ImageID = null
                } // Administrator
            };

            foreach (User u in users)
            {
                //context.Users.Add(u);
                um.CreateAsync(u, u.Password).Wait();
            }
            #endregion
            
            #region Projects
            var projects = new Project[]
            {
                new Project {
                    ID = Guid.Parse("b2704079-637e-4f0e-81ff-ea2c4b1b95cf"),
                    Name = "Erste banka",
                    Description = "Projekat za Erste banku.",
                    UserID = Guid.Parse("c68af42e-fd7c-4ebb-a8d1-f714a47f60a7")
                }, // Stefan
                new Project{
                    ID = Guid.Parse("c6849ed9-26fe-4d2e-ae06-8990cbec0906"),
                    Name = "Pekara 021",
                    Description = "Projekat za pekaru \"021\".",
                    UserID = Guid.Parse("c68af42e-fd7c-4ebb-a8d1-f714a47f60a7")
                }, // Stefan
                new Project {
                    ID = Guid.Parse("1d14ec23-210c-45e6-acaf-779a209f287c"),
                    Name = "Veš servis",
                    Description = "Projekat za perionicu veša \"Veš servis\".",
                    UserID = Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08")
                }, // Dušan
                new Project {
                    ID = Guid.Parse("35466694-cb7e-43fa-803f-434b7636c749"),
                    Name = "Exit",
                    Description = "Projekat za muzički festival \"Exit\"",
                    UserID = Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08")
                }, // Dušan
                new Project {
                    ID = Guid.Parse("ba98ed8f-abce-4745-8081-5853fbf3142a"),
                    Name = "Studentski centar Novi Sad",
                    Description = "Projekat za Studentski centar u Novom Sadu.",
                    UserID = Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08")
                } // Dušan
            };
            foreach (Project p in projects)
            {
                context.Projects.Add(p);
            }
            context.SaveChanges();
            #endregion

            #region TaskGroups
            var taskGroups = new TaskGroup[]
            {
                new TaskGroup {
                    ID = Guid.Parse("cfaba562-3760-4065-8a64-2020e03442de"),
                    Name = "Sajt",
                    Description = "Web sajt za Erste banku.",
                    ProjectID = Guid.Parse("b2704079-637e-4f0e-81ff-ea2c4b1b95cf")
                }, // Stefan, Erste banka
                new TaskGroup {
                    ID = Guid.Parse("e0db44f1-4704-4a90-8e51-506297803976"),
                    Name = "Android aplikacija",
                    Description = "Android aplikacija za Erste banku.",
                    ProjectID = Guid.Parse("b2704079-637e-4f0e-81ff-ea2c4b1b95cf")
                } // Stefan, Erste banka
            };
            foreach (TaskGroup tg in taskGroups)
            {
                context.TaskGroups.Add(tg);
            }
            context.SaveChanges();
            #endregion

            #region Tasks
            var tasks = new Task[]
            {
                new Task {
                    ID = Guid.Parse("304ea812-5153-4992-a8bc-da8c22ab1fad"),
                    Name = "Dizajn",
                    Description = "Potrebno je dizajnirati novi sajt Erste banke.",
                    Finished = false,
                    DueDate = DateTime.Parse("2021-04-15T09:00:00"),
                    TaskGroupID = Guid.Parse("cfaba562-3760-4065-8a64-2020e03442de")
                }, // Stefan, Erste banka, Sajt
                new Task {
                    ID = Guid.Parse("ff237276-30b2-42ef-ae5d-155e3255486f"),
                    Name = "Baza podataka",
                    Description = "Potrebno je isprojektovati bazu podataka za novi sajt Erste banke.",
                    Finished = false,
                    DueDate = DateTime.Parse("2021-04-25T10:00:00"),
                    TaskGroupID = Guid.Parse("cfaba562-3760-4065-8a64-2020e03442de")
                } // Stefan, Erste banka, Sajt
            };
            foreach (Task t in tasks)
            {
                context.Tasks.Add(t);
            }
            context.SaveChanges();
            #endregion

            #region Labels
            var labels = new Label[]
            {
                new Label {
                    ID = Guid.Parse("9be61ae2-9898-4ebb-80ad-53cff3355b84"),
                    Name = "Dizajn"
                },
                new Label {
                    ID = Guid.Parse("eca84b44-94a5-4d4d-8eea-ed773095d80b"),
                    Name = "Programiranje"
                }
            };
            foreach (Label l in labels)
            {
                context.Labels.Add(l);
            }
            context.SaveChanges();
            #endregion

            #region Subtasks
            var subtasks = new Subtask[]
            {
                new Subtask {
                    ID = Guid.Parse("707a5752-c849-4f78-8c66-875c23a9bf6d"),
                    Name = "Dizajn početne strane",
                    Finished = true,
                    TaskID = Guid.Parse("304ea812-5153-4992-a8bc-da8c22ab1fad")
                },
                new Subtask {
                    ID = Guid.Parse("3a0f44e5-bddd-4d68-adfe-28ab9a889b18"),
                    Name = "Dizajn logoa",
                    Finished = true,
                    TaskID = Guid.Parse("304ea812-5153-4992-a8bc-da8c22ab1fad")
                }
            };
            foreach (Subtask st in subtasks)
            {
                context.Subtasks.Add(st);
            }
            context.SaveChanges();
            #endregion

            #region TaskRoles
            var taskRoles = new TaskRole[]
            {
                new TaskRole {
                    ID = Guid.Parse("02bfe263-c45c-4e32-8c9f-fb3bc3f2be66"),
                    Name = "Programer"
                }, 
                new TaskRole {
                    ID = Guid.Parse("274e5f62-bddc-4aa7-aec2-ae0ee925ef5b"),
                    Name = "Dizajner"
                }
            };
            foreach (TaskRole tr in taskRoles)
            {
                context.TaskRoles.Add(tr);
            }
            context.SaveChanges();
            #endregion

            #region UserTasks
            var userTasks = new UserTask[]
            {
                new UserTask {
                    AssignmentDate = DateTime.Parse("2021-03-26T09:00:00"),
                    EstimatedEndDate = DateTime.Parse("2021-04-01T10:00:00"),
                    ActualEndDate = DateTime.Parse("2021-03-29T11:00:00"),
                    UserID = Guid.Parse("fe556bd9-f1bb-4f6a-b2b1-245f8daf9c08"),
                    TaskID = Guid.Parse("304ea812-5153-4992-a8bc-da8c22ab1fad"),
                    TaskRoleID = Guid.Parse("274e5f62-bddc-4aa7-aec2-ae0ee925ef5b")
                }, // Stefan, Erste banka, Sajt, Dizajn, Dizajner
                new UserTask {
                    AssignmentDate = DateTime.Parse("2021-03-26T09:00:00"),
                    EstimatedEndDate = DateTime.Parse("2021-04-01T10:00:00"),
                    ActualEndDate = DateTime.Parse("2021-03-29T11:00:00"),
                    UserID = Guid.Parse("c68af42e-fd7c-4ebb-a8d1-f714a47f60a7"),
                    TaskID = Guid.Parse("304ea812-5153-4992-a8bc-da8c22ab1fad"),
                    TaskRole = null
                } // Stefan, Erste banka, Sajt, Dizajn
            };
            foreach (UserTask ut in userTasks)
            {
                context.UserTasks.Add(ut);
            }
            context.SaveChanges();
            #endregion

            #region ProPlans
            var proPlans = new ProPlan[]
            {
                new ProPlan {
                    ID = Guid.Parse("23f2209e-2921-4e01-8f66-63790acaca6f"),
                    Name = "Pro Silver",
                    Active = true,
                    Price = 10
                },
                new ProPlan {
                    ID = Guid.Parse("408e2add-b6ff-4762-bdc1-31caf2584dfd"),
                    Name = "Pro Gold",
                    Active = true,
                    Price = 15
                },
                new ProPlan {
                    ID = Guid.Parse("3a11f288-17d6-431b-98bb-c47a906d84f0"),
                    Name = "Pro Platinum",
                    Active = true,
                    Price = 20
                }
            };
            foreach (ProPlan pp in proPlans)
            {
                context.ProPlans.Add(pp);
            }
            context.SaveChanges();
            #endregion
        }
    }
}