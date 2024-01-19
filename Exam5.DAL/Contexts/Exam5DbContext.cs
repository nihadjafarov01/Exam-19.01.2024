using Exam5.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam5.DAL.Contexts
{
    public class Exam5DbContext : IdentityDbContext
    {
        public Exam5DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
