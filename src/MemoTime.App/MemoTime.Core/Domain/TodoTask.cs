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
        public bool Done { get; protected set; }

        protected TodoTask()
        {
            
        }
        
        public TodoTask(Guid id, string name, Guid userId, Project project, DateTime dueDate)
        {
            Id = id;
            Name = name;
            UserId = userId;
            DueDate = dueDate;
            CreatedAt = DateTime.UtcNow;
            Project = project;
            Done = false;
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

        public void SetDone()
        {
            Done = true;
        }
    }
}