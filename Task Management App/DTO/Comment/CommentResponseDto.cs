using System;

namespace Task_Management_System.Models.DTO.Comment
{
    public class CommentResponseDto
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTime PostedOnDate { get; set; }
        public Guid UserID { get; set; }
        public string UserFullName { get; set; }
        public Guid TaskID { get; set; }
    }
}
