using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemoTime.Core.Domain
{
    public class Project : Entity
    {
        private ISet<TodoTask> _tasks = new HashSet<TodoTask>();
        
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }

        public IEnumerable<TodoTask> Tasks
        {
            get => _tasks;
            set => _tasks = new HashSet<TodoTask>(value);
        }
        public DateTime StartDate { get; protected set; }
        public DateTime DueDate { get; protected set; }

        protected Project()
        {
            
        }
        
        public Project(Guid id, Guid userId, string name)
        {
            Id = id;
            UserId = userId;
            Name = name;
        }

        public void AddTask(Guid id, string name, DateTime dueDate)
        {
           _tasks.Add(new TodoTask(id, name, UserId, this, dueDate));
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}