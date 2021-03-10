using Lab1.Infrastructure;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;
using Lab1.Repositories.SQLRepositories;
using Lab1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Lab1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Lab1", Version = "v1"}); });
            
            #region SQL repositories
            services.AddTransient<IStationRepository, StationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion

            #region SQL services
            services.AddTransient<IStationService, StationService>();
            services.AddTransient<IUserService, UserService>();
            #endregion
            
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}