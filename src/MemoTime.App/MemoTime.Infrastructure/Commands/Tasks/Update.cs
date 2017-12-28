using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Tasks
{
    public class Update: ICommand
    {
        public Guid TaskId { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }
}