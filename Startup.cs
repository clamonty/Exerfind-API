using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exerfind.Data;
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
using Newtonsoft.Json.Serialization;

namespace API
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

            // Add a DbContext dependency injection of type ExerfindContext to our API
            // Pass in lambda expression supplying options to the context
            // UseSqlServer, and configure with ConnectionString ExerfindConnection (found in appsettings.json)aa
            services.AddDbContext<ExerfindContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ExerfindConnection")));


            services.AddControllers().AddNewtonsoftJson(s =>
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            // Add AutoMapper functionalities
            // Requires access to current assemblies of our project
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // Add scoped dependency injection
            // Whenever a constructor requires an IExerfindRepo parameter, inject the SqlExerfindRepo class
            services.AddScoped<IExerfindRepo, SqlExerfindRepo>();




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exerfind API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exerfind API"));
            }

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
