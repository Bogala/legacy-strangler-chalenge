using System.Collections.Generic;

using legacy_business_logic.Entities;
using legacy_business_logic.Providers;
using legacy_business_logic.Repositories;
using legacy_business_logic.Validators;

using INewUserRepository = new_business_logic.User.IUserRepository;
using NewUserRepository = new_business_logic.User.UserRepository;

namespace legacy_business_logic.Services
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetUserById(int userId);

        EnrichedUser GetEnrichedUserById(int userId);

        object GetAll();

        void UpdateUser(User model);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly INewUserRepository _newUserRepository;

        private readonly ISocialReferentialProvider _socialReferentialProvider;

        public UserService()
            : this(new UserRepository(), new NewUserRepository(), new SocialReferentialProvider())
        {
        }

        public UserService(IUserRepository userRepository, INewUserRepository newUserRepository, ISocialReferentialProvider socialReferentialProvider)
        {
            _userRepository = userRepository;
            _newUserRepository = newUserRepository;
            _socialReferentialProvider = socialReferentialProvider;
        }

       
        public void AddUser(User user)
        {
            SocialIdentifierValidator.Validate(user.SocialIdentifier);
            _userRepository.AddUser(user);
        }

        public object GetAll()
        {
            return _newUserRepository.GetAll();
        }

        public void UpdateUser(User user)
        {
            SocialIdentifierValidator.Validate(user.SocialIdentifier);
            _userRepository.UpdateUser(user);
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public EnrichedUser GetEnrichedUserById(int userId)
        {
            EnrichedUser enrichedUser = null;

            var user = _userRepository.GetUserById(userId);
            if (user != null)
            {
                var socialInfo = _socialReferentialProvider.GetSocialInfoByUID(user.SocialIdentifier);
                if (socialInfo != null)
                {
                    enrichedUser = new EnrichedUser()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Address = socialInfo.MainAddress
                    };
                }
            }

            return enrichedUser;
        }
    }
}
