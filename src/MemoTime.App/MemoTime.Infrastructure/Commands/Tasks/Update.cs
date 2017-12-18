using System;

namespace MemoTime.Infrastructure.Commands.Tasks
{
    public class Update
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }
}