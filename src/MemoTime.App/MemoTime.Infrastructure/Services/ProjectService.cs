using System;
using System.Collections.Generic;
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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper,
            ITaskRepository taskRepository)
        {
            _projectRepository = repository;
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        
        public async Task CreateAsync(Guid id, Guid userId, string name)
        {
            var project = new Project(id, userId, name);

            await _projectRepository.AddAsync(project);
        }

        public async Task<ProjectDto> GetAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExists);
            }
            
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<IEnumerable<ProjectDto>> BrowseAsync(Guid userId)
        {
            var projects = await _projectRepository.BrowseAsync(userId);

            if (projects == null)
            {
                throw new ServiceException(ErrorCodes.NoProjectsFound);
            }
            
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task UpdateAsync(Guid projectId, string name)
        {
            var project = await _projectRepository.GetAsync(projectId);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExists);
            }

            project.SetName(name);

            await _projectRepository.UpdateAsync(project);
        }

        public async Task RemoveAsync(Guid id)
        {
            var project = await _projectRepository.GetAsync(id);

            if (project == null)
            {
                throw new ServiceException(ErrorCodes.ProjectNotExist);
            }

            await _projectRepository.RemoveAsync(project);
        }
    }
}