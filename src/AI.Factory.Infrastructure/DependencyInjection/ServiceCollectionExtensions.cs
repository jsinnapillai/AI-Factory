using AI.Factory.Agents;
using AI.Factory.Agents.Consumers;
using AI.Factory.Core.Interfaces;
using AI.Factory.Core.Messaging;
using AI.Factory.Core.Models;
using AI.Factory.Infrastructure.Database;
using AI.Factory.Infrastructure.Database.Repositories;
using AI.Factory.Infrastructure.EventBus;
using AI.Factory.Infrastructure.Logging;
using AI.Factory.Infrastructure.Messaging;
using AI.Factory.Orchestrator.Graph;
using AI.Factory.Orchestrator.Services;
using AI.Factory.TaskEngine;
using AI.Factory.TaskEngine.Models;
using AI.Factory.TaskEngine.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 



namespace AI.Factory.Infrastructure.DependencyInjection
 
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
                     options.UseNpgsql(
           configuration.GetConnectionString("DefaultConnection")));

            // Configuration
            services.Configure<DatabaseConfig>(configuration.GetSection("Database"));
            services.Configure<EventBusConfig>(configuration.GetSection("EventBus"));
            services.Configure<LoggingConfig>(configuration.GetSection("Logging"));

            // Database
            services.AddSingleton<PostgresConnectionFactory>();
            services.AddSingleton<InitialMigration>();

            // Repositories
            services.AddScoped<IRepository<Agent>, BaseRepository<Agent>>();
            services.AddScoped<IRepository<TaskItem>, BaseRepository<TaskItem>>();
            services.AddScoped<IRepository<AI.Factory.Core.Models.Module>, BaseRepository<AI.Factory.Core.Models.Module>>();
            services.AddScoped<IRepository<Plan>, BaseRepository<Plan>>();
            services.AddScoped<IRepository<ExecutionLog>, BaseRepository<ExecutionLog>>();

            // Event Bus
 
            services.AddSingleton<EventBusService>();

            // Logging
            var loggingConfig = configuration.GetSection("Logging").Get<LoggingConfig>() ?? new LoggingConfig();
            var loggerFactory = new LoggerFactory(loggingConfig);
            var logger = loggerFactory.CreateSystemLogger();
            services.AddSingleton(logger);
            services.AddLogging(builder => builder.AddSerilog(logger));

            // Services
            services.AddSingleton<AgentRegistryService>();
            services.AddScoped<ITaskGraphService, TaskGraphService>();
            services.AddScoped<IntentRouterService>();
            services.AddScoped<MasterOrchestratorService>();

            services.AddScoped<EventPublisher>();
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                // Register Consumers
                x.AddConsumer<BAAgentConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });


            services.AddScoped<TaskEngineService>();
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.AddSingleton<GraphBuilder>();
            services.AddScoped<OrchestratorEngine>();

            //            Database
            //Repositories
            //MassTransit
            //Messaging
            //Logging
            //Services

            return services;
        }
    }
}
