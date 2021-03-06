// <auto-generated />
using System;
using Fiba.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiba.DAL.Migrations
{
    [DbContext(typeof(FibaDbContext))]
    [Migration("20210819070445_DatabaseGenerated.None")]
    partial class DatabaseGeneratedNone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiba.DAL.Entities.Gender", b =>
                {
                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GenderId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<bool>("Postseason")
                        .HasColumnType("bit");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitorTeamId")
                        .HasColumnType("int");

                    b.Property<int>("VisitorTeamScore")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("VisitorTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.HasIndex("GenderId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.PlayerTeam", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOfContract")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfContract")
                        .HasColumnType("datetime2");

                    b.HasKey("PlayerId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayersTeams");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Season", b =>
                {
                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TeamId", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SeasonsTeams");
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

                    b.Property<DateTime>("Minutes")
                        .HasColumnType("datetime2");

                    b.Property<int>("OffensiveRebound")
                        .HasColumnType("int");

                    b.Property<int>("PersonnalFoul")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Rebound")
                        .HasColumnType("int");

                    b.Property<int>("Steal")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointsFieldGoalAttempted")
                        .HasColumnType("int");

                    b.Property<int>("ThreePointsFieldGoalMade")
                        .HasColumnType("int");

                    b.Property<decimal>("ThreePointsFieldGoalPourcentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Turnover")
                        .HasColumnType("int");

                    b.HasKey("StatisticId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ThumbUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.HasIndex("GenderId");

                    b.HasIndex("Name", "GenderId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Match", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Season", "Season")
                        .WithMany("Matches")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "VisitorTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("VisitorTeamId")
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

            modelBuilder.Entity("Fiba.DAL.Entities.PlayerTeam", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Player", "Player")
                        .WithMany("PlayersTeams")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "Team")
                        .WithMany("PlayersTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
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
                        .WithMany("SeasonsTeams")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "Team")
                        .WithMany("SeasonsTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Statistic", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Match", "Match")
                        .WithMany("Statistics")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Player", "Player")
                        .WithMany("Statistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Fiba.DAL.Entities.Team", "Team")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiba.DAL.Entities.Team", b =>
                {
                    b.HasOne("Fiba.DAL.Entities.Gender", "Gender")
                        .WithMany("Teams")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
