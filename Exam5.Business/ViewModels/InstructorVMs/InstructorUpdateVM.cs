using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Exam5.Business.ViewModels.InstructorVMs
{
    public class InstructorUpdateVM
    {
        [MaxLength(64)]
        public string Fullname { get; set; }
        [MaxLength(64)]
        public string Position { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsDeleted { get; set; }
    }
}
