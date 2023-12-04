namespace Demo.Provider
{
    public class JwtOptions
    {
        public string? Issuer { set; get; }
        public string? Audience { set; get; }
        public string? SigningKey { set; get; }
    }
}  