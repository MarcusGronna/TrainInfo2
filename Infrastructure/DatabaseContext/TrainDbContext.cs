using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext;

public class TrainDbContext : DbContext
{
    public DbSet<Train> Trains { get; set; }

    public string DbPath { get; }

    public TrainDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "train.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}
