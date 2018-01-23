using System;

namespace MemoTime.Infrastructure.DTO
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public LabelDto Label { get; set; }
    }
}