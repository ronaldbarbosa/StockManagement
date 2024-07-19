using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagement.Identity.Entities;

namespace StockManagement.Identity
{
    public class IdentityDBContext(DbContextOptions options) : IdentityDbContext<User, Role, Guid>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("Claim");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");

            builder.Entity<IdentityUserLogin<Guid>>(x =>
            {
                x.HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });
                x.HasIndex(ul => ul.UserId);
            });
        }
    }
}
