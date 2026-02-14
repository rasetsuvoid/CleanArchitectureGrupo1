using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Presentation
{
    public static class ConfigurationServices
    {
        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // Register UnitOfWork for repositories
            services.AddScoped<CleanArchitecture.Application.Interfaces.IUnitOfWork, CleanArchitecture.Infrastructure.Repositories.UnitOfWork>();
        }
    }
}
