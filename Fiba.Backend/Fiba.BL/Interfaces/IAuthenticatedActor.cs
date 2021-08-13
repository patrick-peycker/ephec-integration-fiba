using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IAuthenticatedActor
	{ 
		IEnumerable<Team> GetTeamsByGender(IEnumerable<int> playerIds);	
		Task<IEnumerable<Team>> AddTeamsByGenderAsync(Guid genderId, List<Team> Teams);
		IEnumerable<Player> GetPlayersByGender(IEnumerable<int> playerIds);
		Task<IEnumerable<Player>> AddPlayersByGenderAsync(Guid genderId, List<Player> Players);
		bool IsGenderExist(Guid genderId);
		Task<Season> AddSeasonByGenderAsync(Guid genderId, Season Season);
	}
}
