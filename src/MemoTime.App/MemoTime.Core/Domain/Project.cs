using System;
using System.Collections.Generic;

namespace MemoTime.Core.Domain
{
    public class Project 
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IList<Task> Tasks { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime DueDate { get; protected set; }
        public IList<Project> SubProjects { get; protected set; }
    }
}