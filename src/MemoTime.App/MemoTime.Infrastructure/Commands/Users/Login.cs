using System;
using MemoTime.Infrastructure.Handlers;

namespace MemoTime.Infrastructure.Commands.Users
{
    public class Login: ICommand
    {
        public Guid TokenId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}