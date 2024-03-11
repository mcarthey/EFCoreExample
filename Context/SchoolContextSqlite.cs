using EFCoreExample.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class SchoolContextSqlite : SchoolContext
{
    public SchoolContextSqlite(DbContextOptions<SchoolContextSqlite> options) : base(options) { }

    public class SchoolContextSqliteFactory : IDesignTimeDbContextFactory<SchoolContextSqlite>
    {
        public SchoolContextSqlite CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Testing.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SchoolContextSqlite>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));

            return new SchoolContextSqlite(optionsBuilder.Options);
        }
    }
}