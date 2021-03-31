using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid UserRoleID { get; set; }
        public Guid? ImageID { get; set; }

        public UserRole UserRole { get; set; }
        public UserImage UserImage { get; set; }
        public ICollection<Contact> ContactsByUser { get; set; }
        public ICollection<Contact> ContactsByOthers { get; set; }
        public ICollection<Block> BlocksByUser { get; set; }
        public ICollection<Block> BlocksByOthers { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserTask> UserTasks { get; set; }
        public ICollection<UserProject> UserProjects { get; set; }
    }
}
