﻿using System;

namespace Task_Management_System.Models.Dtos
{
    public class TaskPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public DateTime DueDate { get; set; }
        public Guid TaskGroupID { get; set; }
    }
}
