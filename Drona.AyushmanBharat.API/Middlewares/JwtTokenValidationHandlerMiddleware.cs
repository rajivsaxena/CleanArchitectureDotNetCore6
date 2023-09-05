using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace Drona.AyushmanBharat.API.Middlewares
{
    public class JwtTokenValidationHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;

        public JwtTokenValidationHandlerMiddleware(RequestDelegate next, string secretKey)
        {
            _next = next ?? throw new ArgumentNullException();
            _secretKey = secretKey ?? throw new ArgumentNullException(); ;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) return;
            var requestUrl = httpContext.Request.Path;


            ControllerActionDescriptor? controllerActionDescriptor = httpContext
                                                                    .GetEndpoint()?
                                                                    .Metadata
                                                                    .GetMetadata<ControllerActionDescriptor>();
            // allowing token generation route to by-pass the JwtTokenValidationHandlerMiddleware
            // todo : we need to check exact controller name and action Name to by pass the token validation
            // for first time intiating the request for M1 or HPR 
            //todo : need to check what all controller method needs to be bypass from middleware
            if (controllerActionDescriptor?.ControllerName == "HprMasterData" || controllerActionDescriptor?.ControllerName == "HPRUploadDocument" || controllerActionDescriptor?.ControllerName == "HPR" || (controllerActionDescriptor?.ControllerName == "Patient" && controllerActionDescriptor?.ActionName == "GetPatient"))
            {
                // Skip execution for the specific action
                await _next.Invoke(httpContext);
                return;
            }

            // Get the token from the Authorization header
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Validate and decode the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true, // Set to false if you dont want to validate the issuer
                    ValidateAudience = true // Set to false if you dont want to validate the audience
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claims = jwtToken.Claims;

                // Add the validated claims to the current user's identity
                var identity = new ClaimsIdentity(claims, "JwtAuthentication");
                httpContext.User.AddIdentity(identity);
            }
            catch (Exception)
            {
                // Token validation failed, handle the error as needed
                // For example, you can return a 401 Unauthorized response
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
            // Call the next middleware in the pipeline
            await _next.Invoke(httpContext);
        }
    }
}
