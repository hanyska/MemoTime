using System;

namespace MemoTime.Core.Domain
{
    public class User : Entity
    {
        public string Username { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User(Guid id, string username, string email, 
            string password, string salt)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
    }
}