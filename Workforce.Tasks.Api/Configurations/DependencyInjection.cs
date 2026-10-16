using Npgsql;
using Workforce.Tasks.Application.Interfaces;
using Workforce.Tasks.Application.Services;
using Workforce.Tasks.Infrastructure.Repositories;

namespace Workforce.Tasks.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddResolveDependency(this IServiceCollection services, IConfiguration configuration)
        {
            // Database
            var connectionString = configuration.GetConnectionString("Postgres") ?? throw new InvalidOperationException("Connection string Postgres não configurada.");

            services.AddSingleton(NpgsqlDataSource.Create(connectionString));

            // Services
            services.AddScoped<CreateWorkerTaskService>();
            services.AddScoped<GetWorkerTaskService>();

            // Repositories
            services.AddScoped<IWorkerTaskRepository, WorkerTaskRepository>();

            return services;
        }
    }
}