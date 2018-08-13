using System.Collections.Generic;

namespace new_business_logic.User
{
    public interface IUserRepository
    {
        void AddUser(User user);

        IReadOnlyCollection<User> GetAll();
    }

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _users;
        }
    }
}
