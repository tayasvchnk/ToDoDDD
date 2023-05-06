using Microsoft.EntityFrameworkCore;
using ToDoDDD.DAL.Entities;

namespace ToDoDDD.DAL.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions options ) : base(options)
    { }

    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Priority> Priority { get; set; }

}