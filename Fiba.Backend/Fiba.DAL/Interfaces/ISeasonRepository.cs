using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ISeasonRepository : IRepository<Season, Guid>
	{
		Task CreateSeasonAsync(Season Season);
		IEnumerable<Season> RetrieveSeasons(Guid genderId);
		Task<Season> RetrieveSeasonAsync(Guid genderId, int seasonId);
	}
}
