using Fiba.DAL.Entities;
using Fiba.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.DAL.Repositories
{
	public class TeamRepository : ITeamRepository
	{
		private readonly FibaDbContext fibaDbContext;

		public TeamRepository(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} is empty in Team Repository !");
		}

		public IEnumerable<Team> RetrieveTeamsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Team Repository !");

			return fibaDbContext.Teams
				.Include(s => s.Gender)
				.Where(s => s.GenderId == genderId);
		}

		public Task CreateAsync(Team Entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Team> Retrieve()
		{
			return fibaDbContext.Teams
				.Include(t => t.Gender);
		}

		public async Task CreateTeamsAsync(IEnumerable<Team> Teams)
		{
			if (Teams == null)
			{
				throw new ArgumentNullException($"{nameof(Teams)} in Teams Repository !");
			}

			await fibaDbContext.Teams
				.AddRangeAsync(Teams);
		}

		public Task DeleteAsync(Team Entity)
		{
			throw new NotImplementedException();
		}





		public async Task<Team> RetrieveAsync(int id)
		{
			return await fibaDbContext.Teams.FirstOrDefaultAsync(t => t.TeamId == id);
		}

		public Task UpdateAsync(Team Entity)
		{
			throw new NotImplementedException();
		}
	}
}
