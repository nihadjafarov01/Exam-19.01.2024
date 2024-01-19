using Exam5.Business.ViewModels.InstructorVMs;
using Exam5.Core.Models;

namespace Exam5.Business.Services.Interfaces
{
    public interface IInstructorService
    {
        public Task<IEnumerable<InstructorListItemVM>> GetAllAsync();
        public Task CreateAsync(InstructorCreateVM vm);
        public Task<InstructorUpdateVM> UpdateAsync(int id);
        public Task UpdateAsync(int id, InstructorUpdateVM vm);
        public Task DeleteAsync(int id);
    }
}
