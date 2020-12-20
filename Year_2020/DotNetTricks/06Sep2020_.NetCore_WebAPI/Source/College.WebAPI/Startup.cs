using College.WebAPI.BLL;
using College.WebAPI.Constants;
using College.WebAPI.DAL;
using College.WebAPI.DAL.Persistence;
using College.WebAPI.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace College.WebAPI
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

            // Adding EF Core
            var connectionString = Configuration[ApplicationConstants.DataStore.SqlConnectionString];
            services.AddDbContext<CollegeSqlDbContext>(o => o.UseSqlServer(connectionString));

            services.AddDbContext<CollegeCosmosDbContext>(o =>
            o.UseCosmos(Configuration["CosmosDbConnectionStrings:accountEndPoint"],
                        Configuration["CosmosDbConnectionStrings:accountKey"],
                        Configuration["CosmosDbConnectionStrings:databaseName"])
            .EnableSensitiveDataLogging(true));

            // Application Services
            services.AddScoped<IProfessorsSqlBll, ProfessorsSqlBll>();
            services.AddScoped<IProfessorsSqlDal, ProfessorsSqlDal>();

            services.AddScoped<IProfessorsCosmosBll, ProfessorsCosmosBll>();
            services.AddScoped<IProfessorsCosmosDal, ProfessorsCosmosDal>();

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
            });
        }
    }
}
