using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqwareBase.Domain.Data;
using SqwareBase.Domain.Services;

namespace SqwareBase.Domain.Config
{
    public class DomainConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString(nameof(DomainDbContext));
            var migrationAssembly = typeof(DomainDbContext).Assembly.FullName;

            services.AddEntityFrameworkSqlite().AddDbContext<DomainDbContext>(database =>
                database.UseSqlite(connectionString, options => options.MigrationsAssembly(migrationAssembly)));

            services.AddTransient<DomainService>();
            services.AddTransient<DomainDbSeeder>();
            services.AddTransient<WidgetService>();
        }
    }
}
