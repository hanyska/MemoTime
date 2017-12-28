using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Projects
{
    public class Create: ICommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}