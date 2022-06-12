using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class CryptoDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public CryptoDbContext(DbContextOptions<CryptoDbContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<PostReply> PostReplies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<AppUser>(b => { b.ToTable("Users"); });
        builder.Entity<IdentityUserClaim<Guid>>(b => { b.ToTable("UserClaims"); });
        builder.Entity<IdentityUserLogin<Guid>>(b => { b.ToTable("UserLogins"); });
        builder.Entity<IdentityUserToken<Guid>>(b => { b.ToTable("UserTokens"); });
        builder.Entity<IdentityRole<Guid>>(b => { b.ToTable("Roles"); });
        builder.Entity<IdentityRoleClaim<Guid>>(b => { b.ToTable("RoleClaims"); });
        builder.Entity<IdentityUserRole<Guid>>(b => { b.ToTable("UserRoles"); });

        builder.Entity<Post>()
            .HasOne(x => x.Creator)
            .WithOne()
            .HasForeignKey<Post>(z => z.CreatorId);

        builder.Entity<Post>()
            .HasMany(x => x.PostReplies)
            .WithOne(x => x.Parent)
            .HasForeignKey(x => x.ParentPostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<PostReply>()
            .HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<PostReply>(z => z.UserId);
    }
}