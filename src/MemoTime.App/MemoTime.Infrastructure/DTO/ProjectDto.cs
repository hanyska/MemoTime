using System;
using System.Collections;
using System.Collections.Generic;

namespace MemoTime.Infrastructure.DTO
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}