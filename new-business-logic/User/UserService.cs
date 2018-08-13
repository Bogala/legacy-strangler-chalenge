using System.Collections.Generic;

namespace new_business_logic.User
{
    public interface IUserService
    {
        IReadOnlyCollection<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService() 
            : this(new UserRepository())
        {
        }

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void InitApp()
        {
            int i = 0;
            _userRepository.AddUser(new User() { Id = ++i, Name = "David" });
            _userRepository.AddUser(new User() { Id = ++i, Name = "Jean Paul" });
            _userRepository.AddUser(new User() { Id = ++i, Name = "Gonzague" });
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
