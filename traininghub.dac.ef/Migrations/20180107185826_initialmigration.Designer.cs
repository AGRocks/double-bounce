﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using traininghub.dac.ef;
using Traininghub.Data;

namespace traininghub.dac.ef.Migrations
{
    [DbContext(typeof(TrainingHubContext))]
    [Migration("20180107185826_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Traininghub.Data.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ChallengeTime");

                    b.Property<int>("GameId");

                    b.Property<bool>("IsConfirmed");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Challenge");
                });

            modelBuilder.Entity("Traininghub.Data.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("NumberOfPlayers");

                    b.Property<int>("OrganizerId");

                    b.Property<int>("SkillLevel");

                    b.Property<int>("Sport");

                    b.Property<int>("Status");

                    b.Property<int>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.HasIndex("VenueId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Traininghub.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("FavoriteSport");

                    b.Property<string>("FullName");

                    b.Property<bool>("IsActivated");

                    b.Property<string>("Login");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Traininghub.Data.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Traininghub.Data.Challenge", b =>
                {
                    b.HasOne("Traininghub.Data.Game", "Game")
                        .WithMany("Challenges")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Traininghub.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Traininghub.Data.Game", b =>
                {
                    b.HasOne("Traininghub.Data.User", "Organizer")
                        .WithMany("Games")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Traininghub.Data.Venue", "Venue")
                        .WithMany("Games")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
