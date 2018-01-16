using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Tasks
{
    public class FinishTask: ICommand
    {
        public Guid TaskId { get; set; }
    }
}