using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface IMatchRepository : IRepository<Match, int>
	{
		IEnumerable<Match> RetrieveMatchesBySeason(Guid seasonId);
	}
}
