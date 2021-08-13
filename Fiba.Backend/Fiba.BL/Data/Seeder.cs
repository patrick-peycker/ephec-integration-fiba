using Fiba.DAL;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
				var filepath = Path.Combine(environment.ContentRootPath, "Data/gender.json");
				var json = File.ReadAllText(filepath);
				var genders = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Gender>>(json);

				await fibaDbContext.Genders.AddRangeAsync(genders);
				await fibaDbContext.SaveChangesAsync();
			}

			// Teams - Seed
			if (!fibaDbContext.Teams.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/Teams.json");
				List<DAL.Entities.Team> teams = new List<DAL.Entities.Team>();

				using (StreamReader r = new StreamReader(filepath))
				{

					string json = r.ReadToEnd();

					using (JsonDocument document = JsonDocument.Parse(json))
					{
						var root = document.RootElement;

						for (int i = 0; i < root.GetArrayLength(); i++)
						{
							DAL.Entities.Team team = new DAL.Entities.Team();

							team.TeamId = root[i].GetProperty("id").GetInt32();
							team.Name = root[i].GetProperty("full_name").GetString();
							team.City = root[i].GetProperty("city").GetString();
							team.Abbreviation = root[i].GetProperty("abbreviation").GetString();
							team.ThumbUrl = root[i].GetProperty("url").GetString();
							team.GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25");

							teams.Add(team);
						}
					}
				}

				await fibaDbContext.Teams.AddRangeAsync(teams);
				await fibaDbContext.SaveChangesAsync();
			}

			// Season - Seed
			if (!fibaDbContext.Seasons.Any())
			{
				List<DAL.Entities.Season> seasons = new List<DAL.Entities.Season>()
					{
						new DAL.Entities.Season() { SeasonId = Guid.Parse("7956225d-13ab-4235-ac08-66c5277f5e69"), Year = 2016, GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("d6d18ef2-e40d-463d-bf86-41d9971e77fb"), Year = 2017, GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("1fb3216b-f6c0-4818-8d15-0972c8090e67"), Year = 2018, GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("3b23a59d-13f3-4585-beee-cf238ef8d631"), Year = 2019, GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("2126d4b2-831a-407f-b788-c36bae3830d9"), Year = 2016, GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("faedddfc-6167-4ce8-85b5-270d94458a1d"), Year = 2017, GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("6d582f4b-d83b-4b8d-8cb1-85cc63ebe06a"), Year = 2018, GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26") },
						new DAL.Entities.Season() { SeasonId = Guid.Parse("de5ace63-c201-4445-9afc-4e62cc603cd2"), Year = 2019, GenderId = Guid.Parse("eddf827d-8795-4054-93b9-19276dd4af26") }
					};

				await fibaDbContext.Seasons.AddRangeAsync(seasons);
				await fibaDbContext.SaveChangesAsync();
			}

			// Players - Seed
			if (!fibaDbContext.Players.Any())
			{
				List<DAL.Entities.Player> players = new List<DAL.Entities.Player>();

				using (var httpClient = new HttpClient())
				{
					int page = 1;
					int pages = 1;

					do
					{
						var response = await httpClient.GetAsync($"https://www.balldontlie.io/api/v1/players?&page={page}&per_page=100");
						if (response.IsSuccessStatusCode)
						{
							var content = await response.Content.ReadAsStringAsync();

							using (JsonDocument document = JsonDocument.Parse(content))
							{
								var data = document.RootElement.GetProperty("data");

								for (int i = 0; i < data.GetArrayLength(); i++)
								{
									DAL.Entities.Player player = new DAL.Entities.Player();

									player.PlayerId = data[i].GetProperty("id").GetInt32();
									player.FirstName = data[i].GetProperty("first_name").GetString();
									player.LastName = data[i].GetProperty("last_name").GetString();
									player.Position = data[i].GetProperty("position").GetString();
									player.GenderId = Guid.Parse("7a8e0b6f-3e77-4c55-9227-d47325088b25");

									players.Add(player);
								}

								page++;
								pages = document.RootElement.GetProperty("meta").GetProperty("total_pages").GetInt32();
							}

							Thread.Sleep(1000);
						}
					} while (pages >= page);
				}

				await fibaDbContext.Players.AddRangeAsync(players);
				await fibaDbContext.SaveChangesAsync();
			}

			// Matches - Seed (Season 2019)
			if (!fibaDbContext.Matches.Any())
			{
				List<DAL.Entities.Match> matches = new List<DAL.Entities.Match>();

				using (var httpClient = new HttpClient())
				{
					int page = 1;
					int pages = 1;

					do
					{
						var response = await httpClient.GetAsync($"https://www.balldontlie.io/api/v1/games?seasons[]=2019&page={page}&per_page=100");
						if (response.IsSuccessStatusCode)
						{
							var content = await response.Content.ReadAsStringAsync();

							using (JsonDocument document = JsonDocument.Parse(content))
							{
								var data = document.RootElement.GetProperty("data");

								for (int i = 0; i < data.GetArrayLength(); i++)
								{
									DAL.Entities.Match match = new DAL.Entities.Match();

									match.MatchId = data[i].GetProperty("id").GetInt32();
									match.Date = data[i].GetProperty("date").GetDateTime();

									match.Period = data[i].GetProperty("period").GetInt32();
									match.Postseason = data[i].GetProperty("postseason").GetBoolean();
									match.Status = data[i].GetProperty("status").GetString();
									match.Time = DateTime.TryParseExact(data[i].GetProperty("time").GetString(), "m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time) ? time : new DateTime();

									match.SeasonId = Guid.Parse("3b23a59d-13f3-4585-beee-cf238ef8d631");

									match.HomeTeamId = data[i].GetProperty("home_team").GetProperty("id").GetInt32();
									match.HomeTeamScore = data[i].GetProperty("home_team_score").GetInt32();

									match.VisitorTeamId = data[i].GetProperty("visitor_team").GetProperty("id").GetInt32();
									match.VisitorTeamScore = data[i].GetProperty("visitor_team_score").GetInt32();

									matches.Add(match);
								}

								page++;
								pages = document.RootElement.GetProperty("meta").GetProperty("total_pages").GetInt32();
							}

							Thread.Sleep(1000);
						}
					} while (pages >= page);
				}

				await fibaDbContext.Matches.AddRangeAsync(matches);
				await fibaDbContext.SaveChangesAsync();
			}

			// Statisctics - Seed (Season 2019)
			if (!fibaDbContext.Statistics.Any())
			{
				var filepath = Path.Combine(environment.ContentRootPath, "Data/statistics.json");
				var json = File.ReadAllText(filepath);
				var statistics = JsonConvert.DeserializeObject<IEnumerable<DAL.Entities.Statistic>>(json);

				//List<DAL.Entities.Statistic> statistics = new List<DAL.Entities.Statistic>();

				//using (var httpClient = new HttpClient())
				//{
				//	int page = 19;
				//	int pages = 1;

				//	do
				//	{
				//		var response = await httpClient.GetAsync($"https://www.balldontlie.io/api/v1/stats?seasons[]=2019&page={page}&per_page=100");

				//		if (response.IsSuccessStatusCode)
				//		{
				//			var content = await response.Content.ReadAsStringAsync();

				//			using (JsonDocument document = JsonDocument.Parse(content))
				//			{
				//				var data = document.RootElement.GetProperty("data");

				//				for (int i = 0; i < data.GetArrayLength(); i++)
				//				{
				//					DAL.Entities.Statistic statistic = new DAL.Entities.Statistic();
				//					statistic.StatisticId = data[i].GetProperty("id").GetInt32();

				//					statistic.Assist = data[i].GetProperty("ast").GetInt32();
				//					statistic.Block = data[i].GetProperty("blk").GetInt32();
				//					statistic.DefensiveRebound = data[i].GetProperty("dreb").GetInt32();
				//					statistic.ThreePointsFieldGoalPourcentage = data[i].GetProperty("fg3_pct").GetDecimal();
				//					statistic.ThreePointsFieldGoalAttempted = data[i].GetProperty("fg3a").GetInt32();
				//					statistic.ThreePointsFieldGoalMade = data[i].GetProperty("fg3m").GetInt32();
				//					statistic.FieldGoalPourcentage = data[i].GetProperty("fg_pct").GetDecimal();
				//					statistic.FieldGoalAttempted = data[i].GetProperty("fga").GetInt32();
				//					statistic.FieldGoalMade = data[i].GetProperty("fgm").GetInt32();
				//					statistic.FreeTrowPourcentage = data[i].GetProperty("ft_pct").GetDecimal();
				//					statistic.FreeTrowAttempted = data[i].GetProperty("fta").GetInt32();
				//					statistic.FreeTrowMade = data[i].GetProperty("ftm").GetInt32();
				//					statistic.Minutes = DateTime.TryParseExact(data[i].GetProperty("min").GetString(), "m:s", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result) ? result : new DateTime();
				//					statistic.OffensiveRebound = data[i].GetProperty("oreb").GetInt32();
				//					statistic.PersonnalFoul = data[i].GetProperty("pf").GetInt32();
				//					statistic.Points = data[i].GetProperty("pts").GetInt32();
				//					statistic.Rebound = data[i].GetProperty("reb").GetInt32();
				//					statistic.Steal = data[i].GetProperty("stl").GetInt32();
				//					statistic.Turnover = data[i].GetProperty("turnover").GetInt32();

				//					statistic.MatchId = data[i].GetProperty("game").GetProperty("id").GetInt32();
				//					statistic.PlayerId = data[i].GetProperty("player").GetProperty("id").GetInt32();
				//					statistic.TeamId = data[i].GetProperty("team").GetProperty("id").GetInt32();

				//					statistics.Add(statistic);

				//					await fibaDbContext.Statistics.AddAsync(statistic);
				//				}

				//				page++;
				//				pages = document.RootElement.GetProperty("meta").GetProperty("total_pages").GetInt32();
				//			}

				//			Thread.Sleep(1000);
				//		}
				//	} while (pages >= page);
				//}

				//string statisticsJson = JsonConvert.SerializeObject(statistics);
				//File.WriteAllText(Path.Combine(environment.ContentRootPath, "Data/statistics.json"), statisticsJson);

				await fibaDbContext.AddRangeAsync(statistics);
				await fibaDbContext.SaveChangesAsync();
			}
		}
	}
}
