using Microsoft.EntityFrameworkCore;

namespace dtaplace.Models;

public class DTAPlaceDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>();
    }
}