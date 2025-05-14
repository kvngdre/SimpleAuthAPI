using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SimpleAuthAPI.Domain.Entities;

namespace SimpleAuthAPI.Infrastructure.Persistence.Database;

public class ApplicationDbContext : DbContext
{
  public readonly string DbPath;

  public ApplicationDbContext()
  {
    var projectDirectory = Directory.GetCurrentDirectory();
    var infrastructureDirectory = Path.GetFullPath(Path.Combine(projectDirectory, "..", "SimpleAuthAPI.Infrastructure"));
    var folder = Path.Combine(infrastructureDirectory, "Persistence", "Database", "Data");
    Directory.CreateDirectory(folder);
    DbPath = Path.Combine(folder, "simpleAuthAPI.db");
  }

  public DbSet<User> Users { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite($"Data Source={DbPath}");
  }
}