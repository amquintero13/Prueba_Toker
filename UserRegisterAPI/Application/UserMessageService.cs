using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using UserRegisterAPI.Domain;
using UserRegisterAPI.Domain.Contracts;

namespace UserRegisterAPI.Application
{
    public class UserMessageService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserMessageService> _logger;

        public UserMessageService(IUserRepository userRepository, ILogger<UserMessageService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _logger.LogInformation($"Mensaje de bienvenida enviado a {user.Name} al número {user.PhoneNumber}.");
        }
    }
}
