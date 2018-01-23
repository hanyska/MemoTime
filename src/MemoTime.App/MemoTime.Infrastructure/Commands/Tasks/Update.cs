using System;
using MemoTime.Core.Domain;
using MemoTime.Infrastructure.DTO;
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
        public bool Done { get; set; }
        public LabelDto Label { get; set; }
    }
}