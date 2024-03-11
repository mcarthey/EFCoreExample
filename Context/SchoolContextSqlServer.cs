using EFCoreExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class SchoolContextSqlServer : SchoolContext
{
    public SchoolContextSqlServer(DbContextOptions<SchoolContextSqlServer> options) : base(options) { }

    public class SchoolContextSqlServerFactory : IDesignTimeDbContextFactory<SchoolContextSqlServer>
    {
        public SchoolContextSqlServer CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.Production.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SchoolContextSqlServer>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new SchoolContextSqlServer(optionsBuilder.Options);
        }
    }
}
