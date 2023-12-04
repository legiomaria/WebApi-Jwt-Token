using Demo.Identity;

namespace Demo.Provider
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}