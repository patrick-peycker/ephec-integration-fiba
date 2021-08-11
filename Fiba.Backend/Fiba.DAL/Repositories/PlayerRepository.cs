using Fiba.DAL.Entities;
using Fiba.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.DAL.Repositories
{
	public class PlayerRepository : IPlayerRepository
	{
		private readonly FibaDbContext fibaDbContext;

		public PlayerRepository(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} in Player Repository !");
		}

		public IEnumerable<Player> GetPlayersByGender(IEnumerable<int> playerIds)
		{
			if (playerIds == null)
			{
				throw new ArgumentNullException($"{nameof(playerIds)} in Players Repository");
			}

			return fibaDbContext.Players
				.Where(t => playerIds.Contains(t.PlayerId))
				.ToList();
		}

		public async Task CreatePlayersAsync(IEnumerable<Player> Players)
		{
			if (Players == null)
			{
				throw new ArgumentNullException($"{nameof(Players)} in Players Repository !");
			}

			await fibaDbContext.Players
				.AddRangeAsync(Players);
		}

		public Task CreateAsync(Player Entity)
		{
			throw new System.NotImplementedException();
		}

		public Task DeleteAsync(Player Entity)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Player> Retrieve()
		{
			throw new System.NotImplementedException();
		}

		public Task<Player> RetrieveAsync(int id)
		{
			throw new System.NotImplementedException();
		}

		public Task UpdateAsync(Player Entity)
		{
			throw new System.NotImplementedException();
		}
	}
}
