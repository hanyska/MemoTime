using System;

namespace MemoTime.Infrastructure.Commands.Tasks
{
    public class Create
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
    }
}