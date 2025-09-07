using Microsoft.EntityFrameworkCore;
using ToDoAppForKC3.Common;
namespace ToDoAppForKC3.ApiService;

public class ToDoDbContext : DbContext
{
    public DbSet<ToDoData> ToDos { get; set; }
    public string DbPath { get; }
    public ToDoDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var p = Environment.GetFolderPath(folder);
        DbPath = Path.Join(p, "ToDo.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

}
