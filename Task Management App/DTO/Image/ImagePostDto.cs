using System;

namespace Task_Management_System.Models.DTO.Image
{
    public class ImagePostDto
    {
        public string FilePath { get; set; }
        public Guid? UserID { get; set; }
        public Guid? CommentID { get; set; }
        public Guid? TaskID { get; set; }
    }
}
