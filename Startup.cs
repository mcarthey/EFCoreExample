using EFCoreExample.Context;
using EFCoreExample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreExample;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var env = services.BuildServiceProvider().GetRequiredService<IHostEnvironment>();

        if (env.IsEnvironment("Testing"))
        {
            services.AddDbContext<SchoolContextSqlite>(options =>
                options.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISchoolContext>(provider => provider.GetService<SchoolContextSqlite>());
        }
        else
        {
            services.AddDbContext<SchoolContextSqlServer>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISchoolContext>(provider => provider.GetService<SchoolContextSqlServer>());
        }

        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<MainService>();
    }


}