using Fiba.DAL.Entities;
using Fiba.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.DAL.Repositories
{
	public class SeasonRepository : ISeasonRepository
	{
		private readonly FibaDbContext fibaDbContext;

		public SeasonRepository(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} in Season Repository !");
		}

		public Task CreateAsync(Season Entity)
		{
			throw new NotImplementedException();
		}

		public async Task CreateSeasonAsync(Season Season)
		{
			if (Season == null)
			{
				throw new ArgumentNullException($"{nameof(Season)} in Season Repository !");
			}

			await fibaDbContext.Seasons
				.AddAsync(Season);
		}

		public Task DeleteAsync(Season Entity)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Season> RetrieveSeasons(Guid genderId)
		{
			if (genderId == null)
			{
				throw new ArgumentNullException($"{nameof(genderId)} in Season Repository !");
			}

			return fibaDbContext.Seasons
				.Include(s => s.Gender)
				.Where(s => s.GenderId == genderId);
		}

		public IEnumerable<Season> Retrieve()
		{
			throw new NotImplementedException();
		}

		public Task<Season> RetrieveAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Season Entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Season> RetrieveSeasonAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
			{
				throw new ArgumentNullException($"{nameof(genderId)} in Season Repository !");
			}

			return await fibaDbContext.Seasons
				.Include(s => s.Gender)
				.Where(s => s.GenderId == genderId && s.SeasonId == seasonId)
				.FirstOrDefaultAsync();
		}
	}
}
