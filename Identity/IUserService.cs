namespace Demo.Identity
{
    public interface IUserService
    {
        bool IsCredentialsValid(string userName, string password);
        User GetCredentials(string userName);
    }
}