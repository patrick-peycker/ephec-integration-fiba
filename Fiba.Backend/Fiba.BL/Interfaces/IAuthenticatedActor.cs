using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IAuthenticatedActor
	{
		IEnumerable<Team> GetTeamsByGender(IEnumerable<int> isd);
		Task<IEnumerable<Team>> AddTeamsByGenderAsync(Guid genderId, List<Team> Teams);
		Task<IEnumerable<Player>> AddPlayersByGenderAsync(Guid genderId, List<Player> Players);
		IEnumerable<Player> GetPlayersByGender(IEnumerable<int> playerIds);

		Task<Season> AddSeasonForGenderAsync(Guid genderId, Season Season);
	}
}
