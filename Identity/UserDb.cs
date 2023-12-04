namespace Demo.Identity
{
    public class UserDb
    {
        public static List<User> users = new ()
        {
            new User()
            {
                Email = "me@yahoo.com",
                FirstName = "Chika",
                Username = "chichi",
                Password = "VeryPassword",
                Role = "Admin"
            },
            new User()
            {
                Email = "us@yahoo.com",
                FirstName = "Lucky",
                Username = "luc",
                Password = "VeryPassword2",
                Role = "SchoolOwner"
            }
        };
    }
}