using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.PaymentService.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "12345678")
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status401Unauthorized;

                await response.WriteAsync("Bad token");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
