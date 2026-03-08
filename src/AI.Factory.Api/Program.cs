
using AI.Factory.Infrastructure.Database.Repositories;
using AI.Factory.Orchestrator.Services;
using Microsoft.AspNetCore.Builder;
using AI.Factory.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add infrastructure services
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run database migrations
using (var scope = app.Services.CreateScope())
{
    var migration = scope.ServiceProvider.GetRequiredService<InitialMigration>();
    await migration.MigrateAsync();

    var orchestrator = scope.ServiceProvider.GetRequiredService<MasterOrchestratorService>();
    await orchestrator.InitializeAsync();
}

app.Run();
 