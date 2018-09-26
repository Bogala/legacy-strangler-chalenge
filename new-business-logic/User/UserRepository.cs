using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace new_business_logic.User
{
    public interface IUserRepository
    {
        void AddUser(User user);

        IReadOnlyCollection<User> GetAll();
    }

    public class UserRepository : IUserRepository
    {
        private List<User> Load()
        {
            string userDataSource = @"C:\temp\users.datasource";
            if (!File.Exists(userDataSource))
            {
                List<User> users = new List<User>();
                Save(users);

                AddUser(new User() { Name = "David", SocialIdentifier = "".PadLeft(6, 0.ToString()[0]) });
                AddUser(new User() { Name = "Jean Paul", SocialIdentifier = "".PadLeft(6, 1.ToString()[0]) });
                AddUser(new User() { Name = "Gonzague", SocialIdentifier = "".PadLeft(6, 2.ToString()[0]) });
            }

            return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(userDataSource));
        }

        private void Save(List<User> users)
        {
            string userDataSource = @"C:\temp\users.datasource";
            File.WriteAllText(userDataSource, JsonConvert.SerializeObject(users));
        }

        public void AddUser(User user)
        {
            var _users = Load();
            user.Id = user.Id == 0 ? _users.Count + 1 : user.Id;
            _users.Add(user);
            Save(_users);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            var _users = Load();
            return _users;
        }
    }
}
