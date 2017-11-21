using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string username, string role);
    }
}