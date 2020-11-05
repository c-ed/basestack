using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqwareBase.Business.Data;

namespace SqwareBase.Business.Config
{
    public class BusinessConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString(nameof(BusinessDbContext));
            var migrationAssembly = typeof(BusinessDbContext).Assembly.FullName;
            services.AddEntityFrameworkSqlite().AddDbContext<BusinessDbContext>(database =>
                database.UseSqlite(connectionString, options => options.MigrationsAssembly(migrationAssembly)));

            services.AddTransient<BusinessService>();
            services.AddTransient<BusinessDbSeeder>();
        }
    }
}
