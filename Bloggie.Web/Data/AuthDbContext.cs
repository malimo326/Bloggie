using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Roles (User, Admin, SuperAdmin)

            var adminRoleId = "4c76a24a-2127-4954-b904-fd38f09cd7c4";
            var SuperAdminRoleId = "e81428d5-4472-4206-962c-bdc72d6c5360";
            var userRoleId = "ffd0649a-8a7c-4734-adc3-7acd65499430";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,

                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = SuperAdminRoleId,
                    ConcurrencyStamp = SuperAdminRoleId
                },
                new IdentityRole
                {
                     Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
                };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdmenUser

            var superAdminId = "bf5f06b2-c1ec-4d96-954f-8a89897511fa";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId
            };
            // generet password to superAdmin user
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add All roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = superAdminId
            },
                new IdentityUserRole<string>
            {
                RoleId = SuperAdminRoleId,
                UserId = superAdminId
            },
                new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = superAdminId
            }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
