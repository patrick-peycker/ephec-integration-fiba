using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface ISeasonRepository : IRepository<Season, Guid>
	{
		IEnumerable<Season> RetrieveSeasonsByGender(Guid genderId);
		Task CreateSeasonAsync(Season Season);
		Task<Season> RetrieveSeasonAsync(Guid genderId, Guid seasonId);
	}
}
