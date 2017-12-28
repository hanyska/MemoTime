using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(Guid id, Guid userId, string name);
        Task<ProjectDto> GetAsync(Guid id);
        Task<IEnumerable<ProjectDto>> BrowseAsync(Guid userId);
        Task UpdateAsync(Guid projectId, string name);
        Task RemoveAsync(Guid id);
    }
}