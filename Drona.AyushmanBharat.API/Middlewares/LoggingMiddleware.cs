using Microsoft.AspNetCore.Mvc.Controllers;

namespace Drona.AyushmanBharat.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException(); ;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation($"Request: {httpContext.Request.Method} {httpContext.Request.Path}");
            ControllerActionDescriptor? controllerActionDescriptor = httpContext
                                                                    .GetEndpoint()?
                                                                    .Metadata
                                                                    .GetMetadata<ControllerActionDescriptor>();
            _logger.LogInformation($"{controllerActionDescriptor?.ControllerName} : Controller, Executing : {controllerActionDescriptor?.ActionName}");
            await _next.Invoke(httpContext);
            _logger.LogInformation($"{controllerActionDescriptor?.ControllerName} : Controller, Executed : {controllerActionDescriptor?.ActionName}");
        }
    }
}
