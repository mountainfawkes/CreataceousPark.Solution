using Microsoft.EntityFrameworkCore;

namespace CreataceousPark.Models
{
  public class CreataceousParkContext : DbContext
  {
    public CreataceousParkContext(DbContextOptions<CreataceousParkContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }

    public DbSet<Headline> Headlines { get; set; }
  }
}