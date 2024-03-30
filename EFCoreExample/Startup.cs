using EFCoreExample.Contexts;
using EFCoreExample.Contexts.Repositories;
using EFCoreExample.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreExample
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var env = services.BuildServiceProvider().GetRequiredService<IHostEnvironment>();

            if (env.IsEnvironment("Testing"))
            {
                var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection"));
                connection.Open();

                services.AddDbContext<SchoolContextSqlite>(options =>
                    options.UseSqlite(connection));
                services.AddScoped<ISchoolContext>(provider => provider.GetService<SchoolContextSqlite>());
            }
            else
            {
                services.AddDbContext<SchoolContextSqlServer>(options =>
                    options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
                services.AddScoped<ISchoolContext>(provider => provider.GetService<SchoolContextSqlServer>());
            }

            // Registering the SchoolRepository and MainService with the dependency injection container.
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<MainService>();
        }
    }
}
