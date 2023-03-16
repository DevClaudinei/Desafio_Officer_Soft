using CadastroPessoa.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // ChangeTracker.LazyLoadingEnabled = false;
        // ChangeTracker.AutoDetectChangesEnabled = false;
        // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public DbSet<Pessoa> Pessoas {get; set;}
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Infrastructure.Data"));
    // }
}
