﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface ITaskService
    {
        Task CreateAsync(string name, Guid userId, Guid projectId);
        Task<TaskDto> GetAsync(Guid id);
        Task<IEnumerable<TaskDto>> BrowseAsync(Guid projectId); //possilby to delete
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid taskId, Guid projectId, string name, DateTime dueDate);
    }
}