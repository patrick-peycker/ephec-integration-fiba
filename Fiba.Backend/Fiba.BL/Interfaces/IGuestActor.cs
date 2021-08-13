using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IGuestActor
	{
		IEnumerable<Gender> GetGenders();
		IEnumerable<Season> GetSeasonsByGender(Guid genderId);
	
		IEnumerable<Team> GetTeams();
		Task<Season> GetSeasonAsync(Guid genderId, Guid seasonId);

		IEnumerable<Team> GetTeamsByGender(Guid genderId);
		Team GetTeam(Guid genderId, int teamId);
	}
}
