using EFCoreExample.Contexts.Factories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts;

public class SchoolContextSqlite : SchoolContext
{
    public SchoolContextSqlite(DbContextOptions<SchoolContextSqlite> options) : base(options) { }

    public class SchoolContextSqliteFactory : SchoolContextFactory<SchoolContextSqlite>
    {
        protected override void ConfigureOptionsBuilder(DbContextOptionsBuilder<SchoolContextSqlite> optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override SchoolContextSqlite CreateContext(DbContextOptions<SchoolContextSqlite> options)
        {
            return new SchoolContextSqlite(options);
        }
    }
}