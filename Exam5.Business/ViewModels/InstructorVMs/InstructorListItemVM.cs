﻿namespace Exam5.Business.ViewModels.InstructorVMs
{
    public class InstructorListItemVM
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
