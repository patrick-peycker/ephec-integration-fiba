using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IAuthenticatedActor
	{
		Task AddSeasonAsync(Season season);
		Task<Season> GetSeasonForGenderdAsync(Guid genderId, Guid seasonId);

		IEnumerable<Team> GetTeamsByGender(IEnumerable<int> isd);
		Task<IEnumerable<Team>> AddTeamsCollectionForGenderAsync(Guid genderId, List<Team> Teams);
		Task<IEnumerable<Player>> AddPlayersByGenderAsync(Guid genderId, List<Player> Players);
		IEnumerable<Player> GetPlayersByGender(IEnumerable<int> playerIds);

	}
}
