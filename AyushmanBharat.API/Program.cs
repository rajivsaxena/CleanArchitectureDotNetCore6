using AyushmanBharat.API.Extensions;
using AyushmanBharat.Application;
using AyushmanBharat.Infrastructure;
using AyushmanBharat.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ApplicationDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<PatientContextSeed>>();
    //PatientContextSeed.SeedAsync(context, logger: logger).Wait();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
