using System;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Exceptions;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task RegisterAsync(Guid id, string username, string email, string password)
        {
            var user = await _userRepository.GetAsync(username);

            if (user != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.EmailInUse, $"Email '{email} is already in use.'");
            }

            user = await _userRepository.GetByUsernameAsync(username);

            if (user != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.UsernameInUser, $"Username '{username} is already in use.'");
            }
            
            user = new User(id, username, email, password, "salt");

            await _userRepository.AddAsync(user);
        }
    }
}