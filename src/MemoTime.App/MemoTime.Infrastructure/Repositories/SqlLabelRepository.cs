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
    public class SqlLabelRepository: ILabelRepository
    {
        private readonly TodoContext _context;

        public SqlLabelRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Label> GetAsync(Guid id, Guid userId)
            => await _context.Labels
                .Where(x => x.User.Id == userId)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Label>> BrowseAsync(Guid userId)
            => await _context.Labels.Where(x => x.User.Id == userId).ToListAsync();

        public async Task AddAsync(Label label)
        {
            await _context.Labels.AddAsync(label);

            await _context.SaveChangesAsync();
        } 
    }
}