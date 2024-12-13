using System.Collections.Generic;
using UserRegisterAPI.Domain;
using UserRegisterAPI.Domain.Contracts;

namespace UserRegisterAPI.Infrastructure
{
    public class MemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
