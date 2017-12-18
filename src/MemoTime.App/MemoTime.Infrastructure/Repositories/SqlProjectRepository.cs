using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;

namespace MemoTime.Infrastructure.Repositories
{
    public class SqlProjectRepository : IProjectRepository
    {
        private readonly TodoContext _context;

        public SqlProjectRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Project> GetAsync(Guid id)
            => await _context.Projects
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Project>> BrowseAsync(Guid userId)
            => await _context.Projects.Where(x => x.UserId == userId).ToListAsync();

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Project project)
        {
            _context.Remove(project);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            await _context.SaveChangesAsync();
        }
    }
}