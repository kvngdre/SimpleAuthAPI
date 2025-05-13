using Microsoft.EntityFrameworkCore;
using SimpleAuthAPI.Domain.Entities;

namespace SimpleAuthAPI.Infrastructure.Persistence.Database;

public class ApplicationDbContext : DbContext
{
  public readonly string DbPath = "./Persistence/Database/Data/simpleAuthAPI.db";

  public DbSet<User> Users { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlite($"Data Source={DbPath}");
  }
}