using DrugsApt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugsApt.Infrastructure.Dal;

public class DrugsBotDbContext : DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options) { }


    public DbSet<Drug> Drugs { get; set; }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<DrugItem> DrugItems { get; set; }
    public DbSet<DrugStore> DrugStores { get; set; }
    public DbSet<FavoriteDrug>  FavoriteDrugs { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DrugsBotDbContext).Assembly);
    }
}
