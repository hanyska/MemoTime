using System;
using System.Collections.Generic;

namespace MemoTime.Infrastructure.DTO
{
    public class TasksOverviewDto
    {
        public ProjectDto Current { get; set; }
        public IEnumerable<ProjectDto> Expired { get; set; }
    }
}