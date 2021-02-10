using Masny.DotNet.TransactionSystem.PaymentService.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Masny.DotNet.TransactionSystem.PaymentService.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMiddleware>();
        }
    }
}