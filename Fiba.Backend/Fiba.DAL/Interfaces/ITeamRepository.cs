using Fiba.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ITeamRepository : IRepository<Team, int>
	{
		IEnumerable<Team> GetTeamsByGender(IEnumerable<int> teamIds);
		Task CreateTeamsAsync(IEnumerable<Team> Teams);
	}
}
