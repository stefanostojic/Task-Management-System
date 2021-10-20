using System;

namespace Task_Management_System.Models
{
    public class Image : BaseEntity
    {
        public string FilePath { get; set; }
        public Guid? UserID { get; set; }
        public virtual User User { get; set; }
        public Guid? CommentID { get; set; }
        public virtual Comment Comment { get; set; }
        public Guid? TaskID { get; set; }
        public virtual Task Task { get; set; }
    }
}
