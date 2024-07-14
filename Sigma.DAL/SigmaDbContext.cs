using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sigma.DAL.Entities.User;

namespace Sigma.DAL;

public class SigmaDbContext : DbContext
{
    public SigmaDbContext(DbContextOptions<SigmaDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
