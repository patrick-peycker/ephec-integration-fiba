using Fiba.DAL.Entities;
using System;

namespace Fiba.DAL.Interfaces
{
	public interface IGenderRepository : IRepository<Gender, Guid>
	{
		bool DoesGenderExist(Guid genderId);
	}
}
