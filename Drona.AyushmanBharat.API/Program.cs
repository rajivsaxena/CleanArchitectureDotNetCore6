using Drona.AyushmanBharat.API.Extensions;
using Drona.AyushmanBharat.API.Factories;
using Drona.AyushmanBharat.Application;
using Drona.AyushmanBharat.Infrastructure;
using Drona.AyushmanBharat.Infrastructure.Persistance;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
    
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog(LoggerConfigurationFactory.CreateLogger());
});

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Drona HPR API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Drona HPR Api");
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerUI();
}

app.MigrateDatabase<ApplicationDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<PatientContextSeed>>();
    var Hprlogger = services.GetService<ILogger<HPRMasterDataSeed>>();
    HPRMasterDataSeed.SeedAsync(context, logger: Hprlogger).Wait();

    //PatientContextSeed.SeedAsync(context, logger: logger).Wait();
});

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
//todo: read the seceret key from configuration
app.AddCustomMiddleware("72B35A9B6C1CEE6701D1551E9EA72F21D3A823C22E9FE69122C4AC4071A44471");
app.MapControllers();
app.Run();
