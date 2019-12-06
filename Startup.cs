using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MichalRykowskiWebsite.Models;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MichalRykowskiWebsite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt => {
                opt.AddPolicy("_myAllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost");
                });
            });
            services.AddDbContextPool<MessageContext>(
                    opt => opt.UseMySql(Configuration["Data:Connection:ConnectionString"], mysqloptions => 
                    {mysqloptions.ServerVersion(new Version(10, 4, 8), ServerType.MariaDb);})
                );
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes => 
            {
                routes.MapRoute(name:"default", template:"{controller=Home}/{action=Index}");
            });
        }
    }
}
