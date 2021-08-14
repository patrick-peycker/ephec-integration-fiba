using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ISeasonRepository : IRepository<Season, Guid>
	{
		IEnumerable<Season> RetrieveSeasons(Guid genderId);
		Task<Season> RetrieveSeasonByIdAsync(Guid genderId, Guid seasonId);
		Task CreateSeasonAsync(Season Season);
	}
}
