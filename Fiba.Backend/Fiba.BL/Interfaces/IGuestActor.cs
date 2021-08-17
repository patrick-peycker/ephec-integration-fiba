using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IGuestActor
	{
		bool DoesGenderExist(Guid genderId);
		IEnumerable<Gender> GetGenders();
		IEnumerable<Season> GetSeasonsByGender(Guid genderId);
		IEnumerable<Team> GetTeamsByGender(Guid genderId);
		IEnumerable<Player> GetPlayersByGender(Guid genderId);
		IEnumerable<Match> GetMatchesBySeason(Guid seasonId);


		Task<Season> GetSeasonByIdAsync(Guid genderId, Guid seasonId);
	
		IEnumerable<Team> GetTeams();
		Task<Season> GetSeasonAsync(Guid genderId, Guid seasonId);
		Team GetTeam(Guid genderId, int teamId);
	}
}
