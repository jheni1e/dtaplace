using Microsoft.EntityFrameworkCore;

namespace dtaplace.Models;

public class DTAPlaceDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Invitation> Invitations => Set<Invitation>();
    public DbSet<Plan> Plans => Set<Plan>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Pixel> Pixels => Set<Pixel>();
    public DbSet<GiftCard> GiftCards => Set<GiftCard>();
    public DbSet<UserRoom> UserRooms => Set<UserRoom>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
            .HasMany(u => u.UserRooms)
            .WithOne(ur => ur.User)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Room>()
            .HasMany(r => r.UserRooms)
            .WithOne(ur => ur.Room)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<UserRoom>()
            .HasOne(ur => ur.Role);

        mb.Entity<Invitation>()
            .HasOne(r => r.Receiver)
            .WithMany(i => i.Invitations)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Plan>()
            .HasMany(p => p.Users)
            .WithOne(u => u.Plan)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Pixel>()
            .HasOne(p => p.Room)
            .WithMany(r => r.Pixels)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<GiftCard>()
            .HasOne(g => g.Plan)
            .WithMany(p => p.GiftCards);
    }
}