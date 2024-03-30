using EFCoreExample.Contexts.Factories;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Contexts
{
    // This class represents the SchoolContext specifically for SQL Server.
    public class SchoolContextSqlServer : SchoolContext
    {
        // Constructor that accepts DbContextOptions for SchoolContextSqlServer and passes it to the base class.
        public SchoolContextSqlServer(DbContextOptions<SchoolContextSqlServer> options) : base(options)
        {
        }

        // This class is a factory for creating instances of SchoolContextSqlServer.
        public class SchoolContextSqlServerFactory : SchoolContextFactory<SchoolContextSqlServer>
        {
            // This method configures the options builder with the SQL Server connection string.
            protected override void ConfigureOptionsBuilder(DbContextOptionsBuilder<SchoolContextSqlServer> optionsBuilder, string connectionString)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            // This method creates a new instance of SchoolContextSqlServer with the provided options.
            protected override SchoolContextSqlServer CreateContext(DbContextOptions<SchoolContextSqlServer> options)
            {
                return new SchoolContextSqlServer(options);
            }
        }
    }
}
