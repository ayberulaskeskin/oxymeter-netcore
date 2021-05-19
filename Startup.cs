using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;
using oxymeter_netcore.Business.Interfaces;
using oxymeter_netcore.Business.Services;
using oxymeter_netcore.DataAccess.DAO.Interface;
using oxymeter_netcore.DataAccess.DAO.Service;
using Microsoft.AspNetCore.Cors;

namespace oxymeter_netcore
{
    public class Startup
    {
        readonly string allowSpecificOrigins = "_allowSpecificOrigins";
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
                options.AddPolicy(allowSpecificOrigins,
               builder =>
               {
                   builder.WithOrigins("http://localhost:8080")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
               });
            });
            services.AddMvc(opt => {
                opt.EnableEndpointRouting = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com" }
                });
            });
            services.AddControllers();
            services.AddTransient<IMedicalRecordService, MedicalRecordService>();
            services.AddTransient<IMedicalRecordDataAccess, MedicalRecordDataAccess>(x => new MedicalRecordDataAccess(new MySqlConnection(Configuration.GetConnectionString("DBConnection"))));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserDataAccess, UserDataAccess>( x => new UserDataAccess(new MySqlConnection(Configuration.GetConnectionString("DBConnection"))));


            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseCors(allowSpecificOrigins);


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
