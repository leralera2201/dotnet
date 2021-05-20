using System;
using Lab1.Infrastructure;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Lab1.Interfaces.SqlServices;
using Lab1.Mappers;
using Lab1.Repositories.SQLRepositories;
using Lab1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using Lab1.Filters;
using Lab1.Entities;
using Lab1.Utils;

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
            //services.AddCors();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            services.AddDbContext<EfConfig.MyDbContext>(
                options => options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        options => options.EnableRetryOnFailure())
                .EnableSensitiveDataLogging()
            );

            services.AddControllers(options =>
               options.Filters.Add(new ValidationFilter())
           ).AddFluentValidation(options =>
               options.RegisterValidatorsFromAssemblyContaining<Startup>()
           ).AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Lab1", Version = "v1"}); });

            #region AutoMapper
            services.AddAutoMapper(
                typeof(UserProfile),
                typeof(CategoryProfile),
                typeof(TagProfile),
                typeof(ProductProfile),
                typeof(ClientProfile),
                typeof(OrderProfile));
            #endregion
 
            
            #region SQL repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion

            #region SQL services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderService, OrderService>();
            #endregion

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ISortUtils<Category>, SortUtils<Category>>();

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();

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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}