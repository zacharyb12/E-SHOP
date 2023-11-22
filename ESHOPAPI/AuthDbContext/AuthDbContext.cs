using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPAPI.AuthDbContext
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "cac51dc7-1ba7-4f6f-a8ff-02e41e5657cf";
            var adminRoleId = "c0e339a0-26de-40f9-af2d-d8a1c918e364";

            //Create Admin and User Roles

            var roles = new List<IdentityRole>
            { 
                new IdentityRole()
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = userRoleId
                },
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                }
            };

            //Seed the Roles

            builder.Entity<IdentityRole>().HasData(roles);

            //Create Admin User
            var adminUserId = "6550f58d-1349-4edf-9732-c48fa9764f6b";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                NormalizedUserName = "admin@admin.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give Roles To Admin
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = userRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                }
            };
            
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
