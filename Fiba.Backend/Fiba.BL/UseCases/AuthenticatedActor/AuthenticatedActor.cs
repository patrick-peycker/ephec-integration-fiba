using Fiba.BL.Extensions;
using Fiba.BL.Interfaces;
using Fiba.BL.UseCases.Guest;
using Fiba.DAL.Interfaces;
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
			this.fibaUnitOfWork = fibaUnitOfWork ?? throw new ArgumentNullException($"{nameof(fibaUnitOfWork)} in SuperAdministrator Actor !");
		}

		public async Task<IEnumerable<Domain.Team>> AddTeamsByGenderAsync(Guid genderId, List<Domain.Team> Teams)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Administrator Actor !");

			if (Teams == null)
				throw new ArgumentException($"{nameof(Teams)} in Administrator Actor !");

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

		public IEnumerable<Domain.Player> GetPlayersByGender(IEnumerable<int> playerIds)
		{
			return fibaUnitOfWork.PlayerRepository.GetPlayersByGender(playerIds).Select(t=>t.ToDomain());
		}

		public IEnumerable<Domain.Team> GetTeamsByGender(IEnumerable<int> teamsIds)
		{
			return fibaUnitOfWork.TeamRepository.GetTeamsByGender(teamsIds).Select(t=>t.ToDomain());
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

		public async Task<Domain.Season> AddSeasonByGenderAsync(Guid genderId, Domain.Season Season)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Administrator Actor !");

			if (Season == null)
				throw new ArgumentException($"{nameof(Season)} in Administrator Actor !");

			var seasonToCreate = new DAL.Entities.Season();

			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				//Season.SeasonId = Guid.NewGuid();
				//Season.GenderId = genderId;


				//var dateFirstLeg = FirstSaturdayOfMonth(Season.Year, 1);
				//var dateSecondLeg = FirstSaturdayOfMonth(Season.Year, 7);

				//// Rounds for Season
				//for (int i = 0; i < nbOfRounds; i++)
				//{
				//	var round = new Domain.Round();

				//	//Rounds for First Leg
				//	if (i < nbOfRoundsByLeg)
				//	{
				//		round.Id = Guid.NewGuid();
				//		round.Number = i + 1;
				//		round.StartDate = dateFirstLeg;
				//		round.EndDate = dateFirstLeg.AddDays(1);

				//		round.SeasonId = Season.SeasonId;
				//	}

				//	//Rounds for Second Leg
				//	else
				//	{
				//		round.Id = Guid.NewGuid();
				//		round.Number = i + 1;
				//		round.StartDate = dateSecondLeg;
				//		round.EndDate = dateSecondLeg.AddDays(1);

				//		round.SeasonId = Season.SeasonId;
				//	}

				//	// Matches for Round
				//	var matches = new List<Domain.Match>();
				//	for (int j = 0; j < nbOfMatchesByRound; j++)
				//	{
				//		var match = new Domain.Match();

				//		match.Id = Guid.NewGuid();
				//		match.Number = j + 1;

				//		match.RoundId = round.Id;

				//		matches.Add(match);
				//	}

				//	dateFirstLeg = dateFirstLeg.AddDays(7);
				//	dateSecondLeg = dateSecondLeg.AddDays(7);

				//	round.Matches = new List<Domain.Match>(matches);
				//	rounds.Add(round);
				//}

				seasonToCreate = Season.ToEntity();

				await fibaUnitOfWork.SeasonRepository.CreateSeasonAsync(seasonToCreate);
				await fibaUnitOfWork.SaveChangesAsync();

				transaction.Complete();
			};

			return seasonToCreate.ToDomain();
		}

		public bool IsGenderExist(Guid genderId)
		{
			return fibaUnitOfWork.GenderRepository.IsGenderExist(genderId);
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
	}
}
