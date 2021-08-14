using Fiba.DAL.Entities;
using Fiba.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.DAL.Repositories
{
	public class GenderRepository : IGenderRepository
	{
		private readonly FibaDbContext fibaDbContext;

		public GenderRepository(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} in Gender Repository !");
		}

		public IEnumerable<Gender> Retrieve()
		{
			return fibaDbContext.Genders;
		}

		public Task<Gender> RetrieveAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task CreateAsync(Gender Entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Gender Entity)
		{
			throw new NotImplementedException();
		}

		public bool IsGenderExist(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Gender Repository !");

			return fibaDbContext.Genders.Any(g => g.GenderId == genderId);
		}

		public Task UpdateAsync(Gender Entity)
		{
			throw new NotImplementedException();
		}
	}
}
