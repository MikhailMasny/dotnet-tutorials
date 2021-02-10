using Masny.DotNet.TransactionSystem.PaymentService.Contexts;
using Masny.DotNet.TransactionSystem.PaymentService.Contracts.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task InvokeAsync(HttpContext context, PaymentContext paymentContext)
        {
            var token = context.Request.Query["token"];
            var user = paymentContext.Users.AsNoTracking().FirstOrDefault(user => user.Token == token.ToString());
            if (user is null)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status404NotFound;

                await response.WriteAsJsonAsync(new TransactionResponse
                {
                    Description = "User not found",
                });
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}