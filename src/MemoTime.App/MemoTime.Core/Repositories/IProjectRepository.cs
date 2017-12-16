using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Core.Domain;

namespace MemoTime.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetAsync(Guid id);
        Task<IEnumerable<Project>> BrowseAsync(Guid userId);
        Task AddAsync(Project project);
        Task RemoveAsync(Project project);
        Task UpdateAsync(Project project);
    }
}