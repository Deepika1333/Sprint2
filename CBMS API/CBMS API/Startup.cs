using CBMS.BAL.Service;
using CBMS.DAL.Data;
using CBMS.DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBMS_API
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
            var connectionStr = Configuration.GetConnectionString("SqlConnection");
            services.AddDbContext<CityBusManagementDbContext>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddTransient<IRouteDetailsRepository, RouteDetailsRepository>();
            services.AddTransient<RouteDetailsService, RouteDetailsService>();

            services.AddTransient<IBusDetailsRepository, BusDetailsRepository>();
            services.AddTransient<BusDetailsService, BusDetailsService>();

            services.AddTransient<IBusStopRepository, BusStopRepository>();
            services.AddTransient<BusStopService, BusStopService>();

            services.AddTransient<ITripRepository, TripRepository>();
            services.AddTransient<TripService, TripService>();

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<EmployeeService, EmployeeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
