using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IGuestActor
	{
		IEnumerable<Season> GetSeasonsByGender(Guid genderId);
		Task<Season> GetSeasonAsync(Guid genderId, int seasonId);

		IEnumerable<Team> GetTeamsByGender(Guid genderId);
		Team GetTeam(Guid genderId, int teamId);
	}
}
