using System;

namespace MemoTime.Core.Domain
{
    public class TodoTask : Entity
    {
        public Guid UserId { get; protected set; }
        public Guid ProjectId { get; protected set; }
        public string Name { get; protected set; }
        public string Priority { get; protected set; }
        public string Label { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime DueDate { get; protected set; }

        public TodoTask(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}