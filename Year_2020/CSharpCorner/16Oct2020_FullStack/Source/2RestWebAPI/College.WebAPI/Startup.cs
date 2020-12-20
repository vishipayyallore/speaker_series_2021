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

        public IConfiguration Configuration { get; }
        private const string _policyName = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
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

            // Application Services
            services.AddScoped<IProfessorsSqlBll, ProfessorsSqlBll>();
            services.AddScoped<IProfessorsSqlDal, ProfessorsSqlDal>();

//#if DEBUG
//            // services.AddScoped<IProfessorsSqlDal, MockPaymentGateway>();
//#else
//            // services.AddScoped<IProfessorsSqlDal, RealPaymentGateway>();
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
