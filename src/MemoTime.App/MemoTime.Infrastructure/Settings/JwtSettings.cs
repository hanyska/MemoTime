namespace MemoTime.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string ValidIssuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}