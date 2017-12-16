using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        
        public async Task CreateAsync(string name, Guid userId, Guid projectId)
        {
            var task = new TodoTask(name, userId);

            await _taskRepository.AddAsync(task);
        }

        public async Task<TaskDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<TaskDto>> BrowseAsync(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public async  Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}