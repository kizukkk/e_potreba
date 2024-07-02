using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using e_potreba.Domain.Entity;

namespace e_potreba.Infrastructure.DatabaseContext;
public class MsSqlDatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MsSqlDatabaseContext(
        DbContextOptions<MsSqlDatabaseContext> options, 
        IConfiguration configuration
        )
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Toilet> Toilets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
