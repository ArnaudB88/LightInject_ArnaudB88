using LightInject;
using LightInjectAb.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace LightInjectAb.Web.Api
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            //we'll need this in our ConfigureContainer method to replace container registrations
            _services = services;
        }

        // Use this method to add services directly to LightInject
        // Important: This method must exist in order to replace the default provider.
        public void ConfigureContainer(IServiceContainer container)
        {
            //configure our IoC container
            ContainerManager.Bootstrap(container);

            ConfigureApplicationWithContainer(container);
        }
        private void ConfigureApplicationWithContainer(IServiceContainer container)
        {
            _services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
                //.AllowCredentials());
            });
            _services.AddControllers()//support for controllers & api features, not views or pages
                .AddControllersAsServices();

            // swagger
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LightInject API", Version = "v1" });

                foreach (var documentationFilePath in Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "LightInject*.xml"))
                { // Use xml /// documentation
                    c.IncludeXmlComments(documentationFilePath);
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //interactive docs at "/swagger"
                c.EnableValidator();
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "LightInject API v1");
            });
        }
    }
}
