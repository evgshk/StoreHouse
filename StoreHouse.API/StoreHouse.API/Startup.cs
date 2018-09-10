using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using Swashbuckle.AspNetCore.Swagger;
using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Data.Repository.Implementation;
using StoreHouse.API.Services.Interfaces;
using StoreHouse.API.Services.Implementation;

namespace StoreHouse.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Inject DbContext as a service
            services.AddDbContext<StoreHouseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AresStorageConnection")));

            services.AddCors();

            // Add framework services.
            services.AddMvc();

            // Inject services(for business logic)
            services.AddTransient<IStocksService, StocksService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IWarehousesService, WarehousesService>();
            services.AddTransient<IDocumentsService, DocumentsService>();

            // Inject repositories
            services.AddTransient<IStocksRepository, StocksRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IWarehousesRepository, WarehousesRepository>();
            services.AddTransient<IDocumentsRepository, DocumentsRepository>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Shows UseCors with CorsPolicyBuilder.
            //We're gonna locate our client app at port 4200.
            //app.UseCors(builder =>
            //    builder.WithOrigins("http://localhost:4200")
            //           .AllowAnyHeader()
            //    );
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
