using EFSchoolPersistence.EF;
using EFSchoolPersistence.Repository;
using EFSchoolPersistence.Services;
using InMemorySchoolPersistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SchoolModel.Repositories;
using SchoolModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloMvc
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
            services.AddDbContext<SchoolContext>(opt => opt.UseSqlServer("Server = localhost; User Id=sa; Password=1Secure*Password; Database = School")
                .LogTo(Console.WriteLine, new[]
                {
                    DbLoggerCategory.Database.Command.Name
                }, LogLevel.Information).EnableSensitiveDataLogging());
            services.AddControllersWithViews();
            //services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();
            services.AddScoped<IStudentRepository, EFStudentRepository>();
            services.AddScoped<IDidactisService, EFDidactisService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=Index}/{id?}");
            });
        }
    }
}
