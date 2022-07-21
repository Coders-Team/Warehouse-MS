using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Warehouse_MS.Models.Interfaces;
using Warehouse_MS.Models.Services;

namespace Warehouse_MS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
            .AddEntityFrameworkStores<WarehouseDBContext>();

            services.AddTransient<IUserService, IdentityUserService>();

            services.AddDbContext<WarehouseDBContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IProductType, ProductTypeService>();
            services.AddScoped<IStorageType, StorageTypeService>();
            services.AddTransient<IProduct, ProductServices>();

            services.AddScoped<ITransaction, TransactionService>();
            services.AddTransient<IStorage, StorageService>();
            services.AddTransient<IWarehouse, WarehouseService>();

            services.AddControllers()
                   .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Warehouse MS",
                    Version = "v1",
                });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    //options => options.UseDeveloperExceptionPage()
                    options =>
                    {
                        options.Run(
                          async context =>
                          {
                              var exceptions = context.Features.Get<IExceptionHandlerFeature>();
                              if (exceptions != null)
                              {
                                  await context.Response.WriteAsync(exceptions.Error.Message);
                                  context.Response.StatusCode = 500;
                              }
                          });
                    });
            }

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Warehouse MS");
                options.RoutePrefix = "";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}