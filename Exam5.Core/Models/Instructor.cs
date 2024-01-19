using Exam5.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Exam5.Core.Models
{
    public class Instructor : BaseModel
    {
        [MaxLength(64)]
        public string Fullname { get; set; }
        [MaxLength(64)]
        public string Position { get; set; }
        public string ImageUrl { get; set; }
    }
}
