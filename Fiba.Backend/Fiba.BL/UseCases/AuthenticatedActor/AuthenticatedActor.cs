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
			List<int> opponents = new List<int>();
			List<int> days = new List<int>();

			bool home = true;
			int matchId = await fibaUnitOfWork.MatchRepository.RetrieveNewId();
			int nbDays = season.SeasonTeams.Count() - 1;
			int day = 1;
			
			season.SeasonTeams.ForEach(team => teams.Add(team.TeamId));

			foreach (var team in season.SeasonTeams)
			{
				teams.Remove(team.TeamId);

				team.SeasonId = season.SeasonId;

				// Intialize opponents
				opponents.Clear();
				teams.ForEach(team => opponents.Add(team));

				foreach (var opponent in teams)
				{
					index = rnd.Next(opponents.Count);

					season.Matches.Add(new Domain.Match()
					{
						MatchId = matchId,
						Round = home ? 1 : 2,
						Day = day,
						Date = new DateTime(season.Year, 1, 1),
						Status = "20:00",

						HomeTeamId = team.TeamId,
						VisitorTeamId = opponents.ElementAt(index),

						SeasonId = season.SeasonId
					});

					matchId++;

					season.Matches.Add(new Domain.Match()
					{
						MatchId = matchId,
						Round = home ? 2 : 1,
						Day = day,
						Date = new DateTime(season.Year, 1, 1),
						Status = "20:00",

						HomeTeamId = opponents.ElementAt(index),
						VisitorTeamId = team.TeamId,

						SeasonId = season.SeasonId
					});

					matchId++;

					opponents.RemoveAt(index);

					home = !home;

					if (day < nbDays)
						day++;
					else
						day = 1;
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
