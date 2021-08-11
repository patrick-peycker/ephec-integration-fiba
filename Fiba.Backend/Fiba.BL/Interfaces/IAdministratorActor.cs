using Fiba.BL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Interfaces
{
	public interface IAdministratorActor
	{
		bool IsGenderExist(Guid genderId);
		IEnumerable<Gender> GetGenders();
		Task<Season> AddSeasonByGenderAsync(Guid genderId, Season Season);
	}
}
