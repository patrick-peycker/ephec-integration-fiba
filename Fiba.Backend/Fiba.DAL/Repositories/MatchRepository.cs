using Fiba.DAL.Entities;
using Fiba.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiba.DAL.Repositories
{
	public class MatchRepository : IMatchRepository
	{
		private readonly FibaDbContext fibaDbContext;

		public MatchRepository(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} is empty in Match Repository !");
		}

		public IEnumerable<Match> RetrieveMatchesBySeason(Guid seasonId)
		{
			return fibaDbContext.Matches
				.Where(m => m.SeasonId == seasonId)
				.Include(m => m.HomeTeam)
				.Include(m => m.VisitorTeam);
		}

		public Task CreateAsync(Match Entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Match Entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Match> Retrieve()
		{
			throw new NotImplementedException();
		}

		public Task<Match> RetrieveAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Match Entity)
		{
			throw new NotImplementedException();
		}
	}
}
