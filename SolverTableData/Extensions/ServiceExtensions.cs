using Microsoft.Extensions.DependencyInjection;
using SolverTableData.Services;
using SolverTableData.Services.Interfaces;

namespace SolverTableData.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ITableService, TableService>();

            return services;
        }
    }
}
