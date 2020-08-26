using College.BLL;
using College.Cache.DAL;
using College.Cache.DAL.Persistence;
using College.Core.Constants;
using College.Core.Interfaces;
using College.SQLServer.DAL;
using College.SQLServer.DAL.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace College.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string _policyName = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add 
        // services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(o => o.AddPolicy(_policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeSqlDbContext>(o => o.UseSqlServer(connectionString));

            //services.AddDbContext<CollegeCosmosDbContext>(o => 
            //o.UseCosmos(Configuration["CosmosDbConnectionStrings:accountEndPoint"],
            //            Configuration["CosmosDbConnectionStrings:accountKey"],
            //            Configuration["CosmosDbConnectionStrings:databaseName"])
            //.EnableSensitiveDataLogging(true));

            // Application Services
            services.AddScoped<IProfessorsSqlBll, ProfessorsSqlBll>();
            services.AddScoped<IProfessorsSqlDal, ProfessorsSqlDal>();

            // Adding Redis Cache 
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Configuration[Constants.DataStore.RedisConnectionString];
                option.InstanceName = Constants.RedisCacheStore.InstanceName;
            });

            // Redis Cache Dependencies
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration[Constants.DataStore.RedisConnectionString], true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            // Cache Related
            services.AddScoped<IRedisCacheDbContext, RedisCacheDbContext>();
            services.AddScoped<IRedisCacheDbDal, RedisCacheDbDal>();

            // Swagger Open API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "College API", Version = "v1" });
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

            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "College API V1");
            });

        }
    }
}
