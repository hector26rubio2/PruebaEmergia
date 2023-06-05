using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PruebaEmergia.Infrastructure.Data;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System;

namespace SocialMedia.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:5173")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .AllowCredentials());
            });
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Prueba Emergia", Version = "v1" });
            });
            //
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //
            services.AddControllers();
            //
            services.AddDbContext<emergiaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Emergia")));
            //
            services.AddTransient<IFacturaRepository, FacturaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy"); 
            app.UseSwagger();
            app.UseSwaggerUI(options=> {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","API Emergia");
                options.RoutePrefix = string.Empty;
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
