using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.Api.Music.Core.Entities;
using Pri.CleanArchitecture.Music.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.CleanArchitecture.Music.Infrastructure.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Genres
            var genres = new Genre[]
            {
                new Genre {Id = 1, Name = "Metal"},
                new Genre {Id = 2, Name = "Blues"},
                new Genre {Id = 3, Name = "Grunge"},
            };
            //Artists
            var artists = new Artist[]
            {
                new Artist{Id = 1,Name="Walter Capiau Band"},
                new Artist{Id = 2,Name="Bart Soete and the hot bananas"},
                new Artist{Id = 3,Name="Pearl jam"},
            };
            //properties
            var properties = new Property[]
            {
                new Property{Id = 1,Name="Extended version" },
                new Property{Id = 2,Name="Limited edition" },
                new Property{Id = 3,Name="Live version" },
                new Property{Id = 4,Name="Explicit lyrics" },
            };
            //records
            var records = new Record[]
            {
                new Record{Id = 1, Title="Live in Lapscheure",GenreId=2,ArtistId=2,Price=99.00M},
                new Record{Id = 2, Title="Think about the children",GenreId=1,ArtistId=1,Price=9.00M},
                new Record{Id = 3, Title="Ten",GenreId=3,ArtistId=3,Price=299.00M},
            };
            //PropertyRecord
            var propertyRecords = new[]
            {
                new {PropertiesId = 1, RecordsId=1 },
                new {PropertiesId = 1, RecordsId=2 },
                new {PropertiesId = 1, RecordsId=3 },
                new {PropertiesId = 2, RecordsId=1 },
                new {PropertiesId = 2, RecordsId=2 },
                new {PropertiesId = 2, RecordsId=3 },
                new {PropertiesId = 3, RecordsId=1 },
            };
            //records
            var applicationUserRecords = new[]
            {
                new {RecordsId = 1,ApplicationUsersId = "1" },
                new {RecordsId = 2,ApplicationUsersId = "1" },
                new {RecordsId = 3,ApplicationUsersId = "1" },
                new {RecordsId = 1,ApplicationUsersId = "2" },
                new {RecordsId = 2,ApplicationUsersId = "2" },
                new {RecordsId = 3,ApplicationUsersId = "2" },
            };
            //hasdata methods
            //seed users
            var adminUser = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@music.com",
                NormalizedUserName = "ADMIN@MUSIC.COM",
                Email = "admin@music.com",
                NormalizedEmail = "ADMIN@MUSIC.COM",
                DateOfBirth = DateTime.Now,
                Firstname = "Bart",
                Lastname = "Soete",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };
            var user = new ApplicationUser
            {
                Id = "2",
                UserName = "user@music.com",
                NormalizedUserName = "USER@MUSIC.COM",
                Email = "user@music.com",
                NormalizedEmail = "USER@MUSIC.COM",
                DateOfBirth = DateTime.Now,
                Firstname = "Mileto",
                Lastname = "Di Marco",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            //FOR TESTING ONLY!
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Test123");
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123");
            //roles
            var applicationRoles = new IdentityRole[]
            {
                new IdentityRole{Id = "1",Name = "Admin",NormalizedName = "ADMIN"},
                new IdentityRole{Id = "2",Name = "User",NormalizedName = "USER"},
            };
            //add users to role
            var userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = "1",UserId = "1" },//admin
                new IdentityUserRole<string>{RoleId = "2",UserId = "2" }//user
            };
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Artist>().HasData(artists);
            modelBuilder.Entity<Property>().HasData(properties);
            modelBuilder.Entity<Record>().HasData(records);
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, user);
            modelBuilder.Entity<IdentityRole>().HasData(applicationRoles);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            modelBuilder.Entity($"{nameof(Property)}{nameof(Record)}").HasData(propertyRecords);
            modelBuilder.Entity($"{nameof(ApplicationUser)}{nameof(Record)}").HasData(applicationUserRecords);
        }
    }
}
