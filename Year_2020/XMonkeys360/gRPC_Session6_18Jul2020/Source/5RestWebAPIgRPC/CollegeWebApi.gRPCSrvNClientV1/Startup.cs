using College.ApplicationCore.Interfaces;
using College.ServerBLL;
using College.ServerDAL;
using College.WebApi.BAL;
using College.WebApi.Common;
using College.WebApi.Persistence;
using CollegeWebApi.gRPCSrvNClientV1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.WebApi
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
            services.AddControllers();

            services.AddGrpc();

            // ***************** For REST End Points ***************** 
            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<ProfessorsBal>();
            services.AddScoped<ProfessorsDal>();
            // ***************** For REST End Points ***************** 

            // ***************** For gRPC End Points ***************** 
            // Adding EF Core
            var connectionStringV1 = Configuration[Constants.DataStore.SqlConnectionStringV1];
            services.AddDbContext<ServerDAL.Persistence.CollegeDbContext>(o => o.UseSqlServer(connectionStringV1));

            // College Application Services
            services.AddScoped<IProfessorBLL, ProfessorBLL>();
            services.AddScoped<IProfessorDAL, ProfessorDAL>();

            // Adding Redis Cache 
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Configuration[Constants.DataStore.RedisConnectionString];
                option.InstanceName = Constants.RedisCacheStore.InstanceName;
            });
            // ***************** For gRPC End Points ***************** 
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<CollegeGrpcService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });

            });
        }
    }
}
