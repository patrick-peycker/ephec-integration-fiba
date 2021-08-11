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
	public class SuperAdministratorActor : GuestActor, ISuperAdministratorActor
	{
		private readonly IFibaUnitOfWork fibaUnitOfWork;

		public SuperAdministratorActor(IFibaUnitOfWork fibaUnitOfWork) : base(fibaUnitOfWork)
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
	}
}
