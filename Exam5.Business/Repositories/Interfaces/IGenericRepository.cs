using Exam5.Core.Models.Common;

namespace Exam5.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task CreateAsync(T model);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(T model);
        public Task SaveAsync();
    }
}
