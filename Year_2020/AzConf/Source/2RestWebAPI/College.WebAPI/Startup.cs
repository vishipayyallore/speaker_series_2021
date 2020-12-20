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
using StackExchange.Redis;

namespace College.WebAPI
{
    public class Startup
    {
        private const string _policyName = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // The following line enables Application Insights telemetry collection.
            services.AddApplicationInsightsTelemetry();

            /*
            ApplicationInsightsServiceOptions aiOptions = new ApplicationInsightsServiceOptions
            {
                // Disables adaptive sampling.
                EnableAdaptiveSampling = false,

                // Disables QuickPulse (Live Metrics stream).
                EnableQuickPulseMetricStream = false
            };
            services.AddApplicationInsightsTelemetry(aiOptions);
            */

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddCors(o => o.AddPolicy(_policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            // Adding EF Core
            var connectionString = Configuration[Constants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeSqlDbContext>(o => o.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<IProfessorsSqlBll, ProfessorsSqlBll>();
            services.AddScoped<IProfessorsSqlDal, ProfessorsSqlDal>();

            //#if DEBUG
            //            // services.AddScoped<IPaymentGateway, MockPaymentGateway>();
            //#else
            //            // services.AddScoped<IPaymentGateway, RealPaymentGateway>();
            //#endif

            // Redis Cache Dependencies
            services.AddSingleton(sp =>
            {
                var configuration = ConfigurationOptions.Parse(Configuration[Constants.DataStore.RedisConnectionString], true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            // Redis Cache Related
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

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "College.WebAPI V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
