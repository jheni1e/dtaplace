using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace dtaplace.Models;

public class DTAPlaceDbContext(DbContextOptions<DTAPlaceDbContext> opts) : DbContext(opts)
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
        mb.Entity<UserRoom>()
        .HasOne(ur => ur.User)
        .WithMany(u => u.UserRooms)
        .HasForeignKey(ur => ur.UserID)
        .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<UserRoom>()
            .HasOne(ur => ur.Room)
            .WithMany(r => r.UserRooms)
            .HasForeignKey(ur => ur.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<UserRoom>()
            .HasOne(ur => ur.Role)
            .WithOne(r => r.UserRoom)
            .HasForeignKey<UserRoom>(ur => ur.RoleID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<User>()
            .HasOne(u => u.Plan)
            .WithMany(p => p.Users)
            .HasForeignKey(u => u.PlanID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Room>()
            .HasOne(r => r.Creator)
            .WithMany(u => u.Rooms)
            .HasForeignKey(r => r.CreatorID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Invitation>()
            .HasOne(r => r.Receiver)
            .WithMany(i => i.Invitations)
            .HasForeignKey(i => i.ReceiverID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Invitation>()
            .HasOne(i => i.Room)
            .WithMany(r => r.Invitations)
            .HasForeignKey(r => r.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Plan>()
            .HasMany(p => p.Users)
            .WithOne(u => u.Plan)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<Pixel>()
            .HasOne(p => p.Room)
            .WithMany(r => r.Pixels)
            .HasForeignKey(r => r.RoomID)
            .OnDelete(DeleteBehavior.NoAction);

        mb.Entity<GiftCard>()
            .HasOne(g => g.Plan)
            .WithMany(p => p.GiftCards)
            .HasForeignKey(p => p.PlanID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

public class RPlaceDbContextFactory : IDesignTimeDbContextFactory<DTAPlaceDbContext>
{
    public DTAPlaceDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<DTAPlaceDbContext>();
        var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
        options.UseSqlServer(sqlConn);
        return new DTAPlaceDbContext(options.Options);
    }
}