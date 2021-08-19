using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface IMatchRepository : IRepository<Match, int>
	{
		Task<int> RetrieveNewId();
		IEnumerable<Match> RetrieveMatchesBySeason(Guid seasonId);
	}
}
