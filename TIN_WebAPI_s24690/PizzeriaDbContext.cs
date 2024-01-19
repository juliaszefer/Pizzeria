using Microsoft.EntityFrameworkCore;

namespace TIN_WebAPI_s24690;

public class PizzeriaDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;password=P@ssw0rd;database=mysql";
        var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));
        optionsBuilder.UseMySql(connectionString, serverVersion);
        // base.OnConfiguring(optionsBuilder);
    }
}