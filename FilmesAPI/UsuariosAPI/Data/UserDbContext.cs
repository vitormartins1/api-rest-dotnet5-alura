﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosAPI.Models;

namespace UsuariosAPI.Data
{
    public class UserDbContext 
        : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;

        public UserDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration
                .GetValue<string>("admininfo:password")); //"Admin123@"

            builder.Entity<CustomIdentityUser>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 99999,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 99998,
                    Name = "regular",
                    NormalizedName = "REGULAR"
                }
            );
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    RoleId = 99999,
                    UserId = 99999
                }
            );
        }
    }
}
