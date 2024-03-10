using EFCoreExample.Context;
using EFCoreExample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddDbContext<ISchoolContext, SchoolContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<MainService>();
    }
}