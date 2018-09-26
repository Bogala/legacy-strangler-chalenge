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

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
