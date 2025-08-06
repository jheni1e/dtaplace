using Microsoft.EntityFrameworkCore;

namespace dtaplace.Models;

public class DTAPlaceDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
            .HasMany(u => u.Rooms)
            .WithMany(r => r.Users)
            .WithForeignKey(u => u.RoomID)
            .OnDeleteBehavior(DeleteBehavior.NoAction);

        mb.Entity<Room>()
            .HasMany(r => r.Users)
            .WithMany(u => u.Rooms)
            .WithForeignKey(u => u.RoomID)
            .OnDeleteBehavior(DeleteBehavior.NoAction);


        mb.Entity<Invitation>()
            .HasMany(r => r.Users)
            .WithMany(u => u.Rooms)
            .WithForeignKey(u => u.RoomID)
            .OnDeleteBehavior(DeleteBehavior.NoAction);
    }
}