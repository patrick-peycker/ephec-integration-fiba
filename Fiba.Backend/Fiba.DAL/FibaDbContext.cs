using Fiba.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
				optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Fiba;Trusted_Connection=True;MultipleActiveResultSets=true");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Gender - Index
			modelBuilder.Entity<Gender>()
				.HasIndex(g => g.Name)
				.IsUnique();

			// Teams - Index
			modelBuilder.Entity<Team>()
				.HasIndex(t => new { t.Name, t.GenderId })
				.IsUnique();

			// Season - Index
			modelBuilder.Entity<Season>()
				 .HasIndex(s => new { s.GenderId, s.Year })
				 .IsUnique();

			// Player - Index
			//modelBuilder.Entity<Player>()
			//	.HasIndex(p => new { p.FirstName, p.LastName, p.GenderId })
			//	.IsUnique();

			// PlayerTeam - Primary Keys
			modelBuilder.Entity<PlayerTeam>()
				.HasKey(pt => new { pt.PlayerId, pt.TeamId });

			// PlayerTeam - Player - Foreign keys
			modelBuilder.Entity<PlayerTeam>()
				.HasOne(pt => pt.Player)
				.WithMany(p => p.PlayersTeams)
				.HasForeignKey(pt => pt.PlayerId)
				.OnDelete(DeleteBehavior.Restrict);

			// PlayerTeam - Team - Foreign keys
			modelBuilder.Entity<PlayerTeam>()
				.HasOne(pt => pt.Team)
				.WithMany(t => t.PlayersTeams)
				.HasForeignKey(pt => pt.TeamId)
				.OnDelete(DeleteBehavior.Restrict);

			// SeasonTeam - Primary keys
			modelBuilder.Entity<SeasonTeam>()
				.HasKey(st => new { st.TeamId, st.SeasonId });

			// SeasonTeam - Season - Foreign keys
			modelBuilder.Entity<SeasonTeam>()
				.HasOne(st => st.Season)
				.WithMany(s => s.SeasonsTeams)
				.HasForeignKey(st => st.SeasonId)
				.OnDelete(DeleteBehavior.Restrict);

			// SeasonTeam - Team - Foreign keys
			modelBuilder.Entity<SeasonTeam>()
				.HasOne(st => st.Team)
				.WithMany(t => t.SeasonsTeams)
				.HasForeignKey(stm => stm.TeamId)
				.OnDelete(DeleteBehavior.Restrict);

			// Match - Home Match - Foreign Key
			modelBuilder.Entity<Match>()
				.HasOne(m => m.HomeTeam)
				.WithMany(ht => ht.HomeMatches)
				.HasForeignKey(m => new { m.HomeTeamId })
				.OnDelete(DeleteBehavior.Restrict);

			// Match - Away Match - Foreign Key
			modelBuilder.Entity<Match>()
				.HasOne(m => m.VisitorTeam)
				.WithMany(vt => vt.AwayMatches)
				.HasForeignKey(m => new { m.VisitorTeamId })
				.OnDelete(DeleteBehavior.Restrict);

			// Statistics - Player - Foreign Key
			modelBuilder.Entity<Statistic>()
				.HasOne(s => s.Player)
				.WithMany(p => p.Statistics)
				.HasForeignKey(s => s.PlayerId)
				.OnDelete(DeleteBehavior.Restrict);

			// Statistics - Player - Foreign Key
			modelBuilder.Entity<Statistic>()
				.HasOne(s => s.Team)
				.WithMany(t => t.Statistics)
				.HasForeignKey(s => s.TeamId)
				.OnDelete(DeleteBehavior.Restrict);

			// Statistics - Player - Foreign Key
			modelBuilder.Entity<Statistic>()
				.HasOne(s => s.Match)
				.WithMany(m => m.Statistics)
				.HasForeignKey(s => s.MatchId)
				.OnDelete(DeleteBehavior.Restrict);
		}

		public DbSet<Gender> Genders { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<PlayerTeam> PlayersTeams { get; set; }
		public DbSet<Season> Seasons { get; set; }
		public DbSet<SeasonTeam> SeasonsTeams { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Statistic> Statistics { get; set; }
	}
}
