using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface ILabelService
    {
        Task CreateAsync(Guid id, User user, string name);
        Task<LabelDto> GetAsync(Guid id, Guid userId);
        Task<IEnumerable<LabelDto>> BrowseAsync(Guid userId);
    }
}