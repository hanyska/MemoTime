using System;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}