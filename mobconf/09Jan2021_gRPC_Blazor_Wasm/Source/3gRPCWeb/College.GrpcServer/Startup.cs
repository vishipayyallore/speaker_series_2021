using AutoMapper;
using College.Bll;
using College.Core.Common;
using College.Core.Interfaces;
using College.Dal;
using College.Dal.Persistence;
using College.GrpcServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.GrpcServer
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private const string _policyName = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true;
                options.MaxReceiveMessageSize = 20 * 1024 * 1024; // 2 MB
                options.MaxSendMessageSize = 20 * 1024 * 1024; // 5 MB
            });

            services.AddCors(o => o.AddPolicy(_policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(Startup));

            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<IProfessorsBll, ProfessorsBll>();
            services.AddScoped<IProfessorsDal, ProfessorsDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Must be added between UseRouting and UseEndpoints
            app.UseGrpcWeb();

            app.UseCors(_policyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<CollegeService>().EnableGrpcWeb().RequireCors(_policyName);

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
