using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface IPlayerRepository : IRepository<Player, int>
	{
		IEnumerable<Player> RetrievePlayersByGender(Guid genderId);
		IEnumerable<Player> GetPlayersByGender(IEnumerable<int> playerIds);
		Task CreatePlayersAsync(IEnumerable<Player> Players);
	}
}
