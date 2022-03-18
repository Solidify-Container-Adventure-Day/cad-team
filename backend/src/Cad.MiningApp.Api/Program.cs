using Cad.MiningApp.Api;
using Cad.MiningApp.Core.Interfaces;
using Cad.MiningApp.Core.Services.MiningConfiguration;
using Cad.MiningApp.Core.Services.Resource;
using Cad.MiningApp.Infrastructure.Persistence;
using Cad.MiningApp.Infrastructure.Persistence.Repositories.MiningLogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services
    .AddScoped<IResourceService, ResourceService>()
    .AddScoped<IMiningConfigurationService, MiningConfigurationService>()
    .AddScoped<IMiningLogsRepository, MiningLogsRepository>()
    .AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                  .AllowAnyHeader();
        });
});

builder.Configuration.AddEnvironmentVariables();
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<MiningAppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<MinerService>();


var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using var context = serviceScope.ServiceProvider.GetRequiredService<MiningAppDbContext>();
    context.Database.Migrate();
}

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();


// Add endpoints
app.MapGet("/resources/quantity", async (IResourceService service)
    => await service.GetMinedQuantityAsync());

app.MapGet("/statistics", ([FromQuery] DateTime? startTime, IMiningLogsRepository miningRepo)
    => miningRepo.GetMiningReport(startTime));


app.Run();