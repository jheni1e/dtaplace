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

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
            .HasMany(u => u.Rooms);

        mb.Entity<Room>()
            .HasMany(r => r.Users);

        mb.Entity<User_Room>();

        mb.Entity<Invitation>()
            .HasOne(r => r.Receiver)
            .WithForeignKey(r => r.ReceiverID)
            .OnDeleteBehavior(DeleteBehavior.NoAction);
    }
}