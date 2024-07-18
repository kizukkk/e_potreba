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
        modelBuilder.Entity<Toilet>(entity =>
        {
            entity.OwnsOne(e => e.Point, point =>
            {
                point.Property(p => p.longitude).HasColumnName("Longitude");
                point.Property(p => p.latitude).HasColumnName("Latitude");
            });
        });

        base.OnModelCreating(modelBuilder);
    }

}
