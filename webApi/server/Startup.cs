using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using server.Mappers;
using server.Mappers.Impl;
using server.Repositories;
using server.Repositories.Impl;
using server.Services;
using server.Services.Impl;
using webApi.Repositories;

namespace webApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));

            services.AddScoped(typeof(IAddressMapper), typeof(AddressMapper));
            services.AddScoped(typeof(IUserMapper), typeof(UserMapper));
            services.AddScoped(typeof(IAddressService), typeof(AddressService));
            services.AddScoped(typeof(IEmployeeMapper), typeof(EmployeeMapper));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));

            services.AddControllersWithViews();
            services.AddControllers();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UsePathBase(new Microsoft.AspNetCore.Http.PathString("/api"));
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
