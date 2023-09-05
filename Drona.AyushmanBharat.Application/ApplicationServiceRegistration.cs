using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Drona.AyushmanBharat.Application.Behaviours;
using System.Reflection;
using Drona.AyushmanBharat.Application.FacadeServcies;

namespace Drona.AyushmanBharat.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IHPRService), typeof(HPRService));

            return services;
        }
    }
}
