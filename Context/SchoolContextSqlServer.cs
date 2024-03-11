using EFCoreExample.Context;
using Microsoft.EntityFrameworkCore;

public class SchoolContextSqlServer : SchoolContext
{
    public SchoolContextSqlServer(DbContextOptions<SchoolContextSqlServer> options) : base(options) { }
}
