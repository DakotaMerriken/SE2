using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dahkm_MDB.API.Domain.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using dahkm_MDB.Interfaces;
using dahkm_MDB.API.Domain.Repositories;
using dahkm_MDB.API.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace dahkm_MDB
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
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<DahkmDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MonitoringDatabase")));
            services.AddDefaultIdentity<ApplicationUser>()
                  .AddUserManager<UserManager<ApplicationUser>>()
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DahkmDbContext>();

            services.AddScoped<SeedAdmins>();

            services.AddTransient<IMetricsService, MetricsService>();
            services.AddTransient<IMetricsRepository, MetricsRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            services.AddTransient<IVendorService, VendorService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(); 
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
