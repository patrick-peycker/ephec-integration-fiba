using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ITeamRepository : IRepository<Team, int>
	{
		IEnumerable<Team> RetrieveTeamsByGender(Guid genderId);
		Task CreateTeamsAsync(IEnumerable<Team> Teams);
	}
}
