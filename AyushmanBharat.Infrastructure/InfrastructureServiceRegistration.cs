using AyushmanBharat.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AyushmanBharat.Application.Contracts.Persistance;
using AyushmanBharat.Infrastructure.Repositories;
using AyushmanBharat.Application.Models;
using AyushmanBharat.Application.Contracts.Infrastructure;
using AyushmanBharat.Infrastructure.Mail;
using Microsoft.EntityFrameworkCore;

namespace AyushmanBharat.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ABDMConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}