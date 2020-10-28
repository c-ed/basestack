using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BaseStack.Business.Controllers;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using BaseStack.Business.Data;
using Microsoft.EntityFrameworkCore;

namespace BaseStack.Engine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var businessAssebmly = typeof(BaseBusinessController).GetTypeInfo().Assembly;
            var businessPart = new AssemblyPart(businessAssebmly);

            services.AddControllersWithViews()
                .ConfigureApplicationPartManager(partManager => partManager.ApplicationParts.Add(businessPart));

            services.AddRazorPages();

            services.AddEntityFrameworkSqlite().AddDbContext<BusinessDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("LabGoatDbContext"), b => b.MigrationsAssembly("Server")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
