using EFCoreExample.Contexts.Factories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts
{
    // This class represents the SchoolContext specifically for SQLite.
    public class SchoolContextSqlite : SchoolContext
    {
        // Constructor that accepts DbContextOptions for SchoolContextSqlite and passes it to the base class.
        public SchoolContextSqlite(DbContextOptions<SchoolContextSqlite> options) : base(options)
        {
        }

        // This class is a factory for creating instances of SchoolContextSqlite.
        public class SchoolContextSqliteFactory : SchoolContextFactory<SchoolContextSqlite>
        {
            // This method configures the options builder with the SQLite connection string.
            protected override void ConfigureOptionsBuilder(DbContextOptionsBuilder<SchoolContextSqlite> optionsBuilder, string connectionString)
            {
                optionsBuilder.UseSqlite(connectionString);
            }

            // This method creates a new instance of SchoolContextSqlite with the provided options.
            protected override SchoolContextSqlite CreateContext(DbContextOptions<SchoolContextSqlite> options)
            {
                return new SchoolContextSqlite(options);
            }
        }
    }
}
