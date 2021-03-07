﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Contexts;

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("WebAPI.Models.Challenge", b =>
                {
                    b.Property<int>("ChallengeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ChallengeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int>("XP")
                        .HasColumnType("int");

                    b.HasKey("ChallengeId");

                    b.HasIndex("ChallengeTypeId");

                    b.ToTable("Challenge");
                });

            modelBuilder.Entity("WebAPI.Models.ChallengeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChallengeType");
                });

            modelBuilder.Entity("WebAPI.Models.ChallengeUser", b =>
                {
                    b.Property<int>("ChallengeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ExecutionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishHour")
                        .HasColumnType("datetime");

                    b.HasKey("ChallengeId", "UserId", "ExecutionId");

                    b.HasIndex("UserId");

                    b.ToTable("ChallengeUser");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("LevelExperience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebAPI.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserType");
                });

            modelBuilder.Entity("WebAPI.Models.Challenge", b =>
                {
                    b.HasOne("WebAPI.Models.ChallengeType", "ChallengeType")
                        .WithMany("Challenges")
                        .HasForeignKey("ChallengeTypeId");

                    b.Navigation("ChallengeType");
                });

            modelBuilder.Entity("WebAPI.Models.ChallengeUser", b =>
                {
                    b.HasOne("WebAPI.Models.Challenge", "Challenge")
                        .WithMany("ChallengeUsers")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("UserChallenges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.HasOne("WebAPI.Models.UserType", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebAPI.Models.Challenge", b =>
                {
                    b.Navigation("ChallengeUsers");
                });

            modelBuilder.Entity("WebAPI.Models.ChallengeType", b =>
                {
                    b.Navigation("Challenges");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Navigation("UserChallenges");
                });

            modelBuilder.Entity("WebAPI.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
