using System;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.DTO;
using MemoTime.Infrastructure.Exceptions;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
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

        public async Task<TokenDto> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials);
            }

            if (user.Password != password)
            {
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials);
            }

            var jwt = _jwtHandler.CreateToken(username, "user");

            return new TokenDto
            {
                Token = jwt.Token,
                ExpirationTime = jwt.ExpirationTime
            };
        }
    }
}