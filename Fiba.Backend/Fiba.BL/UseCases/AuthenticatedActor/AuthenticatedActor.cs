using Fiba.BL.Extensions;
using Fiba.BL.Interfaces;
using Fiba.BL.UseCases.Guest;
using Fiba.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Fiba.BL.UseCases.SuperAdministrator
{
	public class AuthenticatedActor : GuestActor, IAuthenticatedActor
	{
		private readonly IFibaUnitOfWork fibaUnitOfWork;

		public AuthenticatedActor(IFibaUnitOfWork fibaUnitOfWork) : base(fibaUnitOfWork)
		{
			this.fibaUnitOfWork = fibaUnitOfWork ?? throw new ArgumentNullException($"{nameof(fibaUnitOfWork)} is empty in Authenticated Actor !");
		}

		public async Task AddSeasonAsync(Domain.Season season)
		{
			if (season == null)
				throw new ArgumentException($"{nameof(season)} is empty in Authenticated Actor !");

			season.SeasonId = Guid.NewGuid();
			season.Matches = new List<Domain.Match>();

			Random rnd = new Random();
			int index;

			List<int> teams = new List<int>();

			foreach (var seasonTeam in season.SeasonTeams)
			{
				seasonTeam.SeasonId = season.SeasonId;
				teams.Add(seasonTeam.TeamId);
			}

			// Initialise HomeTeams & AwayTeams


			List<int> HomeTeamsId = new List<int>();
			List<int> AwayTeamsId = new List<int>();

			for (int c = 1; c <= season.SeasonTeams.Count; c++)
			{
				index = rnd.Next(teams.Count());

				if (c <= season.SeasonTeams.Count / 2)
				{
					HomeTeamsId.Add(teams.ElementAt(index));
				}

				else
				{
					AwayTeamsId.Add(teams.ElementAt(index));
				}

				teams.RemoveAt(index);
			}

			var matchId = await fibaUnitOfWork.MatchRepository.RetrieveNewId();

			var nbDaysByRound = (season.SeasonTeams.Count - 1);
			var nbMatchesByDay = season.SeasonTeams.Count / 2;

			for (int dayNr = 1; dayNr <= nbDaysByRound; dayNr++)
			{
				List<int> teamHome = new List<int>();
				List<int> teamAway = new List<int>();

				// Re-Initialize Team Home & Away Team
				for (int i = 0; i < HomeTeamsId.Count; i++)
				{
					if (dayNr % 2 == 0)
					{
						teamHome.Add(AwayTeamsId.ElementAt(i));
						teamAway.Add(teamHome.ElementAt(i));
					}

					else
					{
						teamHome.Add(HomeTeamsId.ElementAt(i));
						teamAway.Add(AwayTeamsId.ElementAt(i));
					}
				}

				for (int matchNr = 1; matchNr <= nbMatchesByDay; matchNr++)
				{
					for (int i = 1; i < teamHome.Count; i++)
					{
						index = rnd.Next(teamAway.Count);

						// Round 1
						Domain.Match matchRound1 = new Domain.Match
						{
							MatchId = matchId,
							Round = 1,
							Day = dayNr,
							Date = new DateTime(season.Year, 1, 1),
							Status = "20:00",

							HomeTeamId = teamHome.ElementAt(i),
							VisitorTeamId = teamAway.ElementAt(index),

							SeasonId = season.SeasonId
						};

						season.Matches.Add(matchRound1);
						matchId++;

						// Round 2
						Domain.Match matchRound2 = new Domain.Match
						{
							MatchId = matchId,
							Round = 2,
							Day = dayNr,
							Date = new DateTime(season.Year, 1, 1),
							Status = "20:00",

							HomeTeamId = matchRound1.VisitorTeamId,
							VisitorTeamId = matchRound1.HomeTeamId,

							SeasonId = season.SeasonId
						};

						season.Matches.Add(matchRound2);
						matchId++;

						teamAway.RemoveAt(index);
					}
				}
			}

			DAL.Entities.Season seasonToCreate = season.ToEntity();

			await fibaUnitOfWork.SeasonRepository.CreateAsync(seasonToCreate);

			try
			{
				int nbRecords = await fibaUnitOfWork.SaveChangesAsync();
			}

			catch (Exception ex)
			{
				throw new Exception($"Failed to Add Season for Gender!e {ex.Message}");
			}
		}

		public async Task<Domain.Season> GetSeasonForGenderdAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in empty Season Controller !");

			DAL.Entities.Season season = await fibaUnitOfWork.SeasonRepository.RetrieveSeasonByIdAsync(genderId, seasonId);

			return season.ToDomain();
		}

		public async Task<IEnumerable<Domain.Team>> AddTeamsByGenderAsync(Guid genderId, List<Domain.Team> Teams)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Authenticated Actor !");

			if (Teams == null)
				throw new ArgumentException($"{nameof(Teams)} is empty in Authenticated Actor !");

			foreach (var team in Teams)
			{
				team.GenderId = genderId;
			}

			IEnumerable<DAL.Entities.Team> teamsToCreate = Teams.Select(t => t.ToEntity());

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				await fibaUnitOfWork.TeamRepository.CreateTeamsAsync(teamsToCreate);
				await fibaUnitOfWork.SaveChangesAsync();

				transaction.Complete();
			}

			return teamsToCreate.Select(t => t.ToDomain());
		}

		public async Task<IEnumerable<Domain.Player>> AddPlayersByGenderAsync(Guid genderId, List<Domain.Player> Players)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Administrator Actor !");

			if (Players == null)
				throw new ArgumentException($"{nameof(Players)} in Administrator Actor !");

			foreach (var Player in Players)
			{
				Player.GenderId = genderId;
			}

			IEnumerable<DAL.Entities.Player> PlayersToCreate = Players.Select(t => t.ToEntity());

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				await fibaUnitOfWork.PlayerRepository.CreatePlayersAsync(PlayersToCreate);
				await fibaUnitOfWork.SaveChangesAsync();

				transaction.Complete();
			}

			return PlayersToCreate.Select(t => t.ToDomain());
		}

		public DateTime FirstSaturdayOfMonth(int year, int month)
		{
			DateTime date = new DateTime(year, month, 1);
			while (date.DayOfWeek != DayOfWeek.Saturday)
			{
				date = date.AddDays(1);
			}
			return date;
		}

		Task<IEnumerable<Domain.Team>> IAuthenticatedActor.AddTeamsCollectionForGenderAsync(Guid genderId, List<Domain.Team> Teams)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Domain.Player> GetPlayersByGender(IEnumerable<int> playerIds)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Domain.Team> GetTeamsByGender(IEnumerable<int> isd)
		{
			throw new NotImplementedException();
		}
	}
}
