using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_MS.Auth.Interfaces;
using Warehouse_MS.Auth.Models;
using Warehouse_MS.Auth.Services;
using Warehouse_MS.Data;
using Warehouse_MS.Models;
using Warehouse_MS.Models.Interfaces;
using Warehouse_MS.Models.Services;

namespace Warehouse_MS
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
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
            .AddEntityFrameworkStores<WarehouseDBContext>();

            services.AddTransient<IUserService, UserService>();

            services.AddDbContext<WarehouseDBContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // Invalid user redirects
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/auth/index");
                options.AccessDeniedPath = new PathString("/auth/index");
            });

            services.AddScoped<IProductType, ProductTypeService>();
            services.AddScoped<IStorageType, StorageTypeService>();
            services.AddTransient<IProduct, ProductServices>();

            services.AddScoped<ITransaction, TransactionService>();
            services.AddTransient<IStorage, StorageService>();
            services.AddTransient<IWarehouse, WarehouseService>();
          
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddControllers()
                   .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
          
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
