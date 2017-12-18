using System;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;

namespace MemoTime.Infrastructure.Repositories
{
    public class SqlTaskRepository : ITaskRepository
    {
        private readonly TodoContext _context;
        
        public SqlTaskRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<TodoTask> GetAsync(Guid id)
            => await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(TodoTask task)
        {
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TodoTask task)
        {
            _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();
        }
    }
}