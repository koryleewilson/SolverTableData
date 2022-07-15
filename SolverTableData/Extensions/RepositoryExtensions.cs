using Microsoft.Extensions.DependencyInjection;
using SolverTableData.Repositories;
using SolverTableData.Repositories.Interfaces;

namespace SolverTableData.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITableRepository, TableRepository>();

            return services;
        }
    }
}
