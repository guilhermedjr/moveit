using System;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserType> UserType { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<ChallengeType> ChallengeType { get; set; }

        public DbSet<Challenge> Challenge { get; set; }

        public DbSet<ChallengeUser> ChallengeUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChallengeUser>()
              .HasKey(c => new { c.ChallengeId, c.UserId, c.ExecutionId });

            modelBuilder.Entity<ChallengeUser>()
              .HasOne(cu => cu.Challenge)
              .WithMany(c => c.ChallengeUsers)
              .HasForeignKey(cu => cu.ChallengeId);

            modelBuilder.Entity<ChallengeUser>()
              .HasOne(cu => cu.User)
              .WithMany(u => u.UserChallenges)
              .HasForeignKey(cu => cu.UserId);

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
    }
}
