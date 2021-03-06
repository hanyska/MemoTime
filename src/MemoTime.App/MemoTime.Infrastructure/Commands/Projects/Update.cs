﻿using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Projects
{
    public class Update: ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}