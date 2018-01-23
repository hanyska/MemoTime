using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Exceptions;
using MemoTime.Infrastructure.Services.Interfaces;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ErrorCodes = MemoTime.Infrastructure.Exceptions.ErrorCodes;

namespace MemoTime.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public TaskService
        (
            ITaskRepository taskRepository, 
            IMapper mapper,
            IProjectRepository projectRepository,
            ILabelRepository labelRepository
        )
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _labelRepository = labelRepository;
        }

        public async Task<TaskDto> GetAsync(Guid id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);
            }

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<ProjectDto>> BrowseTasksAsync(Guid userId, TaskFilter filter = null)
        {
            IEnumerable<TodoTask> tasks;
            
            switch (filter)
            {
                case TaskFilter f when f.Type == "project": //wywalic
                    tasks = await _taskRepository.BrowseProjectTasks(Guid.Parse(filter.Filter));
                    break;
                    
                case TaskFilter f when f.Type == "expired":
                    tasks = await _taskRepository.BrowseExpired(userId);
                    break;
                
                case TaskFilter f when f.Type == "today":
                    tasks = await _taskRepository.BrowseCurrentDay(userId);
                    break;
                    
                case TaskFilter f when f.Type == "next7days":
                    tasks = await _taskRepository.BrowseNextSevenDays(userId);
                    break;
                    
                case TaskFilter f when f.Type == "finished":
                    tasks = await _taskRepository.BrowseFinished(userId);
                    break;
                    
                default:
                    tasks = await _taskRepository.BrowseAsync(userId);

                    if (filter.ByTag)
                    {
                        tasks = tasks
                            .Where(x => x.Label != null)
                            .Where(x => x.Label.Name.ToLowerInvariant()
                                .Replace(" ", "")
                                .Contains(filter.SearchName.Replace(" ", "")
                                    .ToLowerInvariant()
                                )
                            );
                    }
                    else
                    {
                        tasks = tasks
                            .Where(x => x.Name.ToLowerInvariant()
                                .Replace(" ", "")
                                .Contains(filter.SearchName.Replace(" ", "")
                                    .ToLowerInvariant()
                                )
                            );
                    }
                    
                    break;
            }
            

            var todoTasks = tasks.ToList();

            if (!todoTasks.Any())
            {
                tasks = new List<TodoTask>();
                
            }

            var projects = _mapper.Map<ISet<ProjectDto>>(todoTasks
                .Select(todoTask => todoTask.Project)
                .Distinct()
            );

            var browseExpiredAsync = projects.ToList();


            foreach (var project in browseExpiredAsync)
            {
                project.Tasks = new List<TaskDto>();    
            }
            
            foreach (var project in browseExpiredAsync)
            {
                var filteredTasks = todoTasks.Where(x => x.Project.Id == project.Id);

                project.Tasks = _mapper.Map<IEnumerable<TaskDto>>(filteredTasks);

            }

            return browseExpiredAsync;
        }
        
        public async Task<ProjectDto> BrowseAsync(Guid userId, Guid projectId)
        {
            var current = await _projectRepository.GetAsync(projectId);

            return _mapper.Map<ProjectDto>(current);
        }

        public async Task CreateAsync(Guid id, string name, Guid userId, Guid projectId, DateTime dueDate)
        {
            var project = await _projectRepository.GetAsync(projectId);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExist);
            }

            project.AddTask(id, name, dueDate);

            await _projectRepository.UpdateAsync(project);
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

        public async Task UpdateLabelAsync(Guid taskId, Guid labelId)
        {
            var task = await _taskRepository.GetAsync(taskId);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);
            }

            var label = await _labelRepository.GetAsync(labelId, task.UserId);
            task.SetLabel(label);

            await _taskRepository.UpdateAsync(task);
        }

        public async Task FinishAsync(Guid id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);  
            }
            
            task.SetDone();

            await _taskRepository.UpdateAsync(task);
        }
        
        public async Task RemoveAsync(Guid id)
        {
            var task = await _taskRepository.GetAsync(id);

            if (task == null)
            {
                throw new ServiceException(ErrorCodes.TaskNotExist);
            }

            await _taskRepository.RemoveAsync(task);
        }
    }
}