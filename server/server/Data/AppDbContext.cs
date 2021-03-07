using System;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>()
              .Property(c => c.Description)
                .HasMaxLength(200);

            modelBuilder.Entity<User>()
              .Property(u => u.Username)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
              .Property(u => u.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
              .Property(u => u.Email)
                .HasMaxLength(200);
        }

        public DbSet<WebAPI.Data.User> User { get; set; }

        public DbSet<WebAPI.Data.UserType> UserType { get; set; }

        public DbSet<WebAPI.Data.ChallengeType> ChallengeType { get; set; }

    }
}
