using Fiba.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Fiba.DAL
{
	public class FibaDbContext : DbContext
	{
		public FibaDbContext()
		{
		}

		public FibaDbContext(DbContextOptions<FibaDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder is null)
				throw new ArgumentNullException($"{nameof(optionsBuilder)} in Fiba Database Context !");

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"Server=(local);Database=FIBA;Trusted_Connection=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Gender - Index
			modelBuilder.Entity<Gender>()
				.HasIndex(g => g.Name)
				.IsUnique();

			// Gender - Seed
			modelBuilder.Entity<Gender>().HasData(
				new Gender { GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26"), Name = "Female" },
				new Gender { GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25"), Name = "Male" }
			);

			// Teams - Index
			modelBuilder.Entity<Team>()
				.HasIndex(t => new { t.Name, t.GenderId })
				.IsUnique();

			// Teams - Seed
			using (StreamReader r = new StreamReader("..\\Seed\\SeddTeams.json"))
			{
				List<Team> teams = new List<Team>();

				string json = r.ReadToEnd();

				using (JsonDocument document = JsonDocument.Parse(json))
				{
					var root = document.RootElement;
					for (int i = 0; i < root.GetArrayLength(); i++)
					{
						Team team = new Team();

						team.TeamId = root[i].GetProperty("id").GetInt32();
						team.Name = root[i].GetProperty("full_name").GetString();
						team.City = root[i].GetProperty("city").GetString();
						team.Abbreviation = root[i].GetProperty("abbreviation").GetString();
						team.ThumbUrl = root[i].GetProperty("url").GetString();
						team.GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26");

						teams.Add(team);
					}
				}

				modelBuilder.Entity<Team>().HasData(Teams);
			}

			modelBuilder.Entity<Season>()
				 .HasIndex(s => new { s.GenderId, s.Year })
				 .IsUnique();

			modelBuilder.Entity<TeamPlayer>()
				.HasKey(tp => new { tp.TeamId, tp.PlayerId });

			modelBuilder.Entity<TeamPlayer>()
				.HasOne(tp => tp.Team)
				.WithMany(t => t.TeamPlayers)
				.HasForeignKey(tp => tp.TeamId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<TeamPlayer>()
				.HasOne(tp => tp.Player)
				.WithMany(p => p.TeamPlayers)
				.HasForeignKey(tp => tp.PlayerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<SeasonTeam>()
				.HasKey(st => new { st.TeamId, st.SeasonId });

			modelBuilder.Entity<SeasonTeam>()
				.HasOne(st => st.Season)
				.WithMany(s => s.SeasonTeams)
				.HasForeignKey(st => st.SeasonId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<SeasonTeam>()
				.HasOne(stm => stm.Team)
				.WithMany(t => t.SeasonTeams)
				.HasForeignKey(stm => stm.TeamId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<SeasonTeam>()
				.HasMany(st => st.AwayMatches)
				.WithOne(m => m.VisitorTeam)
				.HasForeignKey(m => m.VisitorTeamId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Match>()
				.HasOne(m => m.HomeTeam)
				.WithMany(st => st.HomeMatches)
				.HasForeignKey(m => new { m.HomeTeamId, m.HomeTeamSeasonId });

			modelBuilder.Entity<Match>()
				.HasOne(m => m.VisitorTeam)
				.WithMany(st => st.AwayMatches)
				.HasForeignKey(m => new { m.VisitorTeamId, m.VisitorTeamSeasonId });

			modelBuilder.Entity<Statistic>()
				.HasOne(s => s.TeamPlayer)
				.WithMany(tp => tp.Statistics)
				.HasForeignKey(s => new { s.TeamId, s.PlayerId });
		}

		public DbSet<Gender> Genders { get; set; }
		public DbSet<Season> Seasons { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<TeamPlayer> TeamPlayers { get; set; }
		public DbSet<SeasonTeam> SeasonTeams { get; set; }
		public DbSet<Statistic> Statistics { get; set; }
	}
}
