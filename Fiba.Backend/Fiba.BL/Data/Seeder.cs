using Fiba.DAL;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.Data
{
	public class Seeder
	{
		private readonly FibaDbContext fibaDbContext;
		private readonly IWebHostEnvironment environment;

		public Seeder(FibaDbContext fibaDbContext, IWebHostEnvironment environment)
		{
			this.fibaDbContext = fibaDbContext;
			this.environment = environment;
		}

		public async Task SeedAsync()
		{
			fibaDbContext.Database.EnsureCreated();

			// Genders - Seed
			if (!fibaDbContext.Genders.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/genders.json");
				var json = File.ReadAllText(filepath);
				var genders = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Gender>>(json);

				await fibaDbContext.Genders.AddRangeAsync(genders);
				await fibaDbContext.SaveChangesAsync();
			}

			// Teams - Seed
			if (!fibaDbContext.Teams.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/teams.json");
				var json = File.ReadAllText(filepath);
				var teams = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Team>>(json);

				await fibaDbContext.Teams.AddRangeAsync(teams);
				await fibaDbContext.SaveChangesAsync();
			}

			// Season - Seed
			if (!fibaDbContext.Seasons.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/seasons.json");
				var json = File.ReadAllText(filepath);
				var seasons = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Season>>(json);

				await fibaDbContext.Seasons.AddRangeAsync(seasons);
				await fibaDbContext.SaveChangesAsync();
			}

			// Players - Seed
			if (!fibaDbContext.Players.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/players.json");
				var json = File.ReadAllText(filepath);
				var players = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Player>>(json);

				await fibaDbContext.Players.AddRangeAsync(players);
				await fibaDbContext.SaveChangesAsync();
			}

			// Matches - Seed (Season 2019)
			if (!fibaDbContext.Matches.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/matches.json");
				var json = File.ReadAllText(filepath);
				var matches = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Match>>(json);

				await fibaDbContext.Matches.AddRangeAsync(matches);
				await fibaDbContext.SaveChangesAsync();
			}

			// Statisctics - Seed (Season 2019)
			if (!fibaDbContext.Statistics.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/statistics.json");
				var json = File.ReadAllText(filepath);
				var statistics = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Statistic>>(json);

				await fibaDbContext.AddRangeAsync(statistics);
				await fibaDbContext.SaveChangesAsync();
			}
		}
	}
}
