using System;

namespace MemoTime.Core.Domain
{
    public class TodoTask
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Priority { get; protected set; }
        public string Label { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime DueDate { get; protected set; }
    }
}