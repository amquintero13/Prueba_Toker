using System.Collections.Generic;

namespace UserRegisterAPI.Domain.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        void AddUser(User user);
    }
}
