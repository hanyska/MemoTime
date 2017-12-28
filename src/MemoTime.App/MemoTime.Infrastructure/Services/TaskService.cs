using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Exceptions;
using MemoTime.Infrastructure.Services.Interfaces;
using ErrorCodes = MemoTime.Infrastructure.Exceptions.ErrorCodes;

namespace MemoTime.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        
        public TaskService(ITaskRepository taskRepository, IMapper mapper,
            IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        
        public async Task CreateAsync(Guid id, string name, Guid userId, Guid projectId)
        {
            var project = await _projectRepository.GetAsync(projectId);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExist);
            }
            
            project.AddTask(id, name);

            await _projectRepository.UpdateAsync(project);
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
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);
            }

            await _taskRepository.RemoveAsync(task);
        }

        public async Task UpdateAsync(Guid taskId, Guid projectId, string name, DateTime dueDate)
        {
            var task = await _taskRepository.GetAsync(taskId);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);
            }

            var project = await _projectRepository.GetAsync(projectId);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExist);
            }
            
            task.SetProject(project);
            task.SetName(name);
            task.SetDueDate(dueDate);

            await _taskRepository.UpdateAsync(task);
        }
    }
}