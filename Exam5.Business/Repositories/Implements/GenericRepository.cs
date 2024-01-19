using Exam5.Business.Repositories.Interfaces;
using Exam5.Core.Models.Common;
using Exam5.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Exam5.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        Exam5DbContext _context { get; }
        public GenericRepository(Exam5DbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T model)
        {
            await Table.AddAsync(model);
            await SaveAsync();
        }

        public async Task DeleteAsync(T model)
        {
            Table.Remove(model);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            Table.Update(model);
            await SaveAsync();
        }
    }
}
