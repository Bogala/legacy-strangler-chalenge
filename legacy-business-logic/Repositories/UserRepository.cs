using System.Collections.Generic;
using System.Linq;

using legacy_business_logic.Entities;

namespace legacy_business_logic.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);

        IReadOnlyCollection<User> GetAll();

        User GetUserById(int id);

        void UpdateUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            user.Id = user.Id == 0 ? _users.Count + 1 : user.Id;
            _users.Add(user);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public void UpdateUser(User user)
        {
            _users.Remove(_users.Find(u => u.Id == user.Id));
            _users.Add(user);
        }
    }
}
