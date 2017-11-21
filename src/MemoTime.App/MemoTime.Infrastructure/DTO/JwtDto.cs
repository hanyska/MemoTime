namespace MemoTime.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long ExpirationTime { get; set;  }
    }
}