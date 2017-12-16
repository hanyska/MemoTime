using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(Guid userId, string name);
        Task<ProjectDto> GetAsync(Guid id);
        Task<IEnumerable<ProjectDto>> BrowseAsync(Guid userId);
        Task RemoveAsync(Guid id);
    }
}