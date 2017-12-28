using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Tasks
{
    public class Delete: ICommand
    {
        public Guid Id { get; set; }
    }
}