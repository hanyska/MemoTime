using System;

namespace MemoTime.Core.Domain
{
    public class TodoTask : Entity
    {
        public Guid UserId { get; protected set; } //possibly to delet
        public Project Project { get; protected set; }
        public string Name { get; protected set; }
        public string Priority { get; protected set; }
        public string Label { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime DueDate { get; protected set; }

        protected TodoTask()
        {
            
        }
        
        public TodoTask(string name, Guid userId, Project project)
        {
            Name = name;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            Project = project;
        }

        public void SetProject(Project project)
        {
            if (project == null)
                return;

            Project = project;
        }

        public void SetName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                return;

            Name = name;
        }

        public void SetDueDate(DateTime dueDate)
        {
            if (dueDate == DateTime.MinValue)
            {
                return;
            }
                
            DueDate = dueDate;
        }
    }
}