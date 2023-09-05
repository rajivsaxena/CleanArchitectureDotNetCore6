using Drona.AyushmanBharat.Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Infrastructure.Repositories;
using Drona.AyushmanBharat.Application.Models;
using Drona.AyushmanBharat.Application.Contracts.Infrastructure;
using Drona.AyushmanBharat.Infrastructure.Mail;
using Microsoft.EntityFrameworkCore;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Contracts.Infrastructure.ABDM.HealthProfessionalRegistory;
using Drona.AyushmanBharat.Cache;
using Drona.AyushmanBharat.Application.Contracts.StateManagement;
using Drona.AyushmanBharat.Infrastructure.Cache;
using Drona.AyushmanBharat.Cache.Interface;
using Drona.AyushmanBharat.Cache.Implementations;
using Drona.AyushmanBharat.Infrastructure.Infrastructure.ABDM.HealthProfessionalRegistory;
using Drona.AyushmanBharat.Application.Models.UrlDM.HPR;

namespace Drona.AyushmanBharat.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ABDMConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.Configure<ABDMSandboxKey>(c => configuration.GetSection("ABDMSandboxKey").Bind(c));
            services.Configure<HprApiUrl>(c => configuration.GetSection("HprApiUrl").Bind(c));
            services.AddScoped<IHealthProfessionalRegistory, HealthProfessionalRegistory>();

            services.AddScoped<IHprRepository, HprRepository>();
            services.AddScoped<IHprRegisterProfessionalRepository, HprRegisterProfessionalRepository>();
            services.AddScoped(typeof(ICacheProvider), typeof(CacheProvider));

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<CacheConnectionOptions>(c => configuration.GetSection("Redis").Bind(c));
            services.AddScoped<IRedisCacheProvider, RedisCacheProvider>();
            return services;
        }

    }
}