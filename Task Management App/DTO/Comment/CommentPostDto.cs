using System;

namespace Task_Management_System.Models.DTO.Comment
{
    public class CommentPostDto
    {
        public string Text { get; set; }
        public Guid UserID { get; set; }
        public Guid TaskID { get; set; }
    }
}
