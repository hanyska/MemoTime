using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Users
{
    public class Register: ICommand
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}