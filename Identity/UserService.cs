namespace Demo.Identity
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = UserDb.users;
        }
        public User GetCredentials(string userName)
        {
            return _users.Where(m => m.Username == userName).First();
        }

        public bool IsCredentialsValid(string userName, string password)
        {
            return _users.Any(m => m.Username == userName &&
                            m.Password == password);
        }
    }
}