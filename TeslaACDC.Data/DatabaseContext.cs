using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Album> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder is null)
        {
            return;
        }

        builder.Entity<Album>().ToTable("albums").HasKey(k => k.Id);
        builder.Entity<Artist>().ToTable("artists").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }

}
