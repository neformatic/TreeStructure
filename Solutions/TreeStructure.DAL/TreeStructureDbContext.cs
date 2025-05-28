using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL;

public class TreeStructureDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Tree> Trees { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Journal> Journals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TreeStructureDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();
    }
}