using Microsoft.AspNetCore.Builder;

namespace MemoTime.Api.Framework
{
    public static class Extensions
    {
        public static void UserErrorHandlerMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware(typeof(ErrorHandlerMiddleware));

    }
}