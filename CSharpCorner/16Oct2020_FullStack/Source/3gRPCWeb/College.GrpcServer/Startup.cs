using College.BLL;
using College.Cache.DAL;
using College.Cache.DAL.Persistence;
using College.Core.Constants;
using College.Core.Interfaces;
using College.GrpcServer.Services;
using College.SQLServer.DAL;
using College.SQLServer.DAL.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace College.GrpcServer
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));

            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeSqlDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<IProfessorsSqlBll, ProfessorsSqlBll>();
            services.AddScoped<IProfessorsSqlDal, ProfessorsSqlDal>();

            // Redis Cache Dependencies
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration[Constants.DataStore.RedisConnectionString], true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            // Cache Related
            services.AddScoped<IRedisCacheDbContext, RedisCacheDbContext>();
            services.AddScoped<IRedisCacheDbDal, RedisCacheDbDal>();
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

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGrpcService<GreeterService>();
                // endpoints.MapGrpcService<CollegeGrpcService>();

                endpoints.MapGrpcService<GreeterService>().EnableGrpcWeb().RequireCors("AllowAll");
                endpoints.MapGrpcService<CollegeGrpcService>().EnableGrpcWeb().RequireCors("AllowAll");

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
