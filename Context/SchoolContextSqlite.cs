using EFCoreExample.Context;
using Microsoft.EntityFrameworkCore;

public class SchoolContextSqlite : SchoolContext
{
    public SchoolContextSqlite(DbContextOptions<SchoolContextSqlite> options) : base(options) { }
}