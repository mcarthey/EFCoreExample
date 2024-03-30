using EFCoreExample.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreExample.Contexts.Factories;

// This is an abstract factory class for creating instances of DbContext (TContext).
// It implements IDesignTimeDbContextFactory<TContext> which is an interface provided by EF Core
// to create DbContext instances at design-time (like during migrations).
public abstract class SchoolContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = ConfigurationHelper.GetConfiguration(environmentName);

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();
        ConfigureOptionsBuilder(optionsBuilder, configuration.GetConnectionString("DefaultConnection"));

        return CreateContext(optionsBuilder.Options);
    }

    // Abstract method to configure the options builder with the connection string
    // This method is implemented in the derived class (eg. SchoolContextSqlServerFactory)
    protected abstract void ConfigureOptionsBuilder(DbContextOptionsBuilder<TContext> optionsBuilder, string connectionString);

    // Abstract method to create and return an instance of TContext (DbContext)
    // This method is implemented in the derived class (eg. SchoolContextSqlServerFactory)
    protected abstract TContext CreateContext(DbContextOptions<TContext> options);
}
