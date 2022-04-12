using Microsoft.Extensions.DependencyInjection;
using Ticaret.Persistence.Repositories.ModelRepositories;

namespace Ticaret.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {            
            services.AddDbContext<TicaretDbContext>(opt => opt.UseNpgsql(SqlConfiguration.ConnectionString));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        }
    }
}
