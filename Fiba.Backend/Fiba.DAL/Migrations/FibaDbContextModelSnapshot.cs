﻿// <auto-generated />
using System;
using Fiba.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiba.DAL.Migrations
{
    [DbContext(typeof(FibaDbContext))]
    partial class FibaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiba.DAL.Entities.Gender", b =>
                {
                    b.Property<Guid>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GenderId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            GenderId = new Guid("eddf827d-8795-4054-93b9-19276dd4af26"),
                            Name = "Female"
                        },
                        new
                        {
                            GenderId = new Guid("7a8e0b6f-3e77-4c55-9227-d47325088b25"),
                            Name = "Male"
                        });
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamSeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitorTeamId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorTeamScore")
                        .HasColumnType("int");

                    b.Property<int>("VisitorTeamSeasonId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("HomeTeamId", "HomeTeamSeasonId");

                    b.HasIndex("VisitorTeamId", "VisitorTeamSeasonId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.HasIndex("GenderId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SeasonId");

                    b.HasIndex("GenderId", "Year")
                        .IsUnique();

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.SeasonTeam", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SeasonTeams");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Statistic", b =>
                {
                    b.Property<int>("StatisticId")
                        .HasColumnType("int");

                    b.Property<int>("Assist")
                        .HasColumnType("int");

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<int>("DefensiveRebound")
                        .HasColumnType("int");

                    b.Property<int>("FieldGoalAttempted")
                        .HasColumnType("int");

                    b.Property<int>("FieldGoalMade")
                        .HasColumnType("int");

                    b.Property<decimal>("FieldGoalPourcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FreeTrowAttempted")
                        .HasColumnType("int");

                    b.Property<int>("FreeTrowMade")
                        .HasColumnType("int");

                    b.Property<decimal>("FreeTrowPourcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("OffensiveRebound")
                        .HasColumnType("int");

                    b.Property<int>("PersonnalFoul")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("Rebound")
                        .HasColumnType("int");

                    b.Property<int>("Steal")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointFieldGoalAttempted")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointFieldGoalMade")
                        .HasColumnType("int");

                    b.Property<decimal>("ThreePointFieldGoalPourcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Turnover")
                        .HasColumnType("int");

                    b.HasKey("StatisticId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId", "PlayerId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TeamId");

                    b.HasIndex("GenderId");

                    b.HasIndex("Name", "GenderId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.TeamPlayer", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("TeamId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TeamPlayers");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Match", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.SeasonTeam", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId", "HomeTeamSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.SeasonTeam", "VisitorTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("VisitorTeamId", "VisitorTeamSeasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Player", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Gender", "Gender")
                        .WithMany("Players")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Season", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Gender", "Gender")
                        .WithMany("Seasons")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.SeasonTeam", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Season", "Season")
                        .WithMany("SeasonTeams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "Team")
                        .WithMany("SeasonTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Statistic", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Match", "Match")
                        .WithMany("Statistics")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.TeamPlayer", "TeamPlayer")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Team", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Gender", null)
                        .WithMany("Teams")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.TeamPlayer", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Player", "Player")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "Team")
                        .WithMany("TeamPlayers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
