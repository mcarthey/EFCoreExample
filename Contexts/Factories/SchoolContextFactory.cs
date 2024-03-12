using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreExample.Helpers;

namespace EFCoreExample.Contexts.Factories
{
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

        protected abstract void ConfigureOptionsBuilder(DbContextOptionsBuilder<TContext> optionsBuilder, string connectionString);
        protected abstract TContext CreateContext(DbContextOptions<TContext> options);
    }
}
