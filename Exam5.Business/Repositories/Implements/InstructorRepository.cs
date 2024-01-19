using Exam5.Business.Repositories.Interfaces;
using Exam5.Core.Models;
using Exam5.DAL.Contexts;

namespace Exam5.Business.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(Exam5DbContext context) : base(context)
        {
        }
    }
}
