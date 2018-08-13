using System.Collections.Generic;

using legacy_business_logic.Entities;
using legacy_business_logic.Providers;
using legacy_business_logic.Repositories;
using legacy_business_logic.Validators;

namespace legacy_business_logic.Services
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetUserById(int userId);

        EnrichedUser GetEnrichedUserById(int userId);

        IReadOnlyCollection<User> GetAll();

        void UpdateUser(User model);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly ISocialReferentialProvider _socialReferentialProvider;

        public UserService() 
            : this(new UserRepository(), new SocialReferentialProvider())
        {
        }

        public UserService(IUserRepository userRepository, ISocialReferentialProvider socialReferentialProvider)
        {
            _userRepository = userRepository;
            _socialReferentialProvider = socialReferentialProvider;
        }

        public void InitApp()
        {
            int i = 0;
            AddUser(new User() { Id = ++i, Name = "David", SocialIdentifier = "".PadLeft(6, i.ToString()[0]) });
            AddUser(new User() { Id = ++i, Name = "Jean Paul", SocialIdentifier = "".PadLeft(6, i.ToString()[0]) });
            AddUser(new User() { Id = ++i, Name = "Gonzague", SocialIdentifier = "".PadLeft(6, i.ToString()[0]) });
        }
        
        public void AddUser(User user)
        {
            SocialIdentifierValidator.Validate(user.SocialIdentifier);
            _userRepository.AddUser(user);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _userRepository.GetAll();
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
