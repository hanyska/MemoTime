﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<TodoTask>> BrowseProjectTasks(Guid projectId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.Id == projectId)
                .Where(x => x.Done == false)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<TodoTask>> BrowseExpired(Guid userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.UserId == userId)
                .Where(x => x.DueDate.Date < DateTime.UtcNow.Date)
                .Where(x => x.Done == false)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<TodoTask>> BrowseCurrentDay(Guid userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.UserId == userId)
                .Where(x => x.DueDate.Date == DateTime.UtcNow.Date)
                .Where(x => x.Done == false)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<TodoTask>> BrowseNextSevenDays(Guid userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.UserId == userId)
                .Where(x => x.DueDate.Date >= DateTime.UtcNow.Date && x.DueDate.Date < DateTime.UtcNow.AddDays(7).Date)
                .Where(x => x.Done == false)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<TodoTask>> BrowseFinished(Guid userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.UserId == userId)
                .Where(x => x.DueDate < DateTime.UtcNow)
                .Where(x => x.Done)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoTask>> BrowseAsync(Guid userId)
        {
            return await _context.Tasks
                .Include(x => x.Project)
                .Include(x => x.Label)
                .Where(x => x.Project.UserId == userId)
                .Where(x => x.Done != true)
                .ToListAsync();
        }
        
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