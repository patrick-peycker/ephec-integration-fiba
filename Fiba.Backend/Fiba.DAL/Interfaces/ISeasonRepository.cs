using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ISeasonRepository : IRepository<Season, Guid>
	{
		bool DoesSeasonExist(Guid seasonId);
		IEnumerable<Season> RetrieveSeasons(Guid genderId);
		Task<Season> RetrieveSeasonByIdAsync(Guid genderId, Guid seasonId);
	}
}
