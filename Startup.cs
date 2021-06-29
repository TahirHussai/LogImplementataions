using Log_Implementataions.Contracts;
using Log_Implementataions.Models;
using Log_Implementataions.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Log_Implementataions
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
            services.AddDbContext<ContosoPetsContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "API",
                    Description = "This API document is related to log implementation "
                });
                //var xfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xpath = Path.Combine(AppContext.BaseDirectory, xfile);
                //a.IncludeXmlComments(xpath);
            });
            services.AddSingleton<ILoggerServices, LoggerServices>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(a => {
                a.SwaggerEndpoint("/Swagger/V1/Swagger.json", "API");
                a.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
