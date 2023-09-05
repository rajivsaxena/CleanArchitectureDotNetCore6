using Drona.AyushmanBharat.API.Middlewares;

namespace Drona.AyushmanBharat.API.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder builder, string secretKey)
        {
            builder.UseMiddleware<JwtTokenValidationHandlerMiddleware>(secretKey);
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
