using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;

namespace MemoTime.Infrastructure.Repositories
{
    public class InMemoryProjectRepository : IProjectRepository
    {
        private static IList<Project> _projects = new List<Project>();

        public async Task<Project> GetAsync(Guid id)
            => await Task.FromResult(_projects.FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Project>> BrowseAsync(Guid userId)
            => await Task.FromResult(_projects.Where(x => x.UserId == userId));

        public async Task AddAsync(Project project)
        {
            _projects.Add(project);

            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Project project)
        {           
            _projects.Remove(project);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Project project)
        {
            await Task.CompletedTask;
        }
    }
}