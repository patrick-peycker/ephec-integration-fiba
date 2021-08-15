using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class GenderExtension
	{
		public static Domain.Gender ToDomain(this DAL.Entities.Gender Gender)
		{
			if (Gender == null)
				throw new ArgumentNullException($"{nameof(Gender)} in Gender Extension !");

			return new Domain.Gender
			{
				GenderId = Gender.GenderId,
				Name = Gender.Name,
			};
		}

		public static DAL.Entities.Gender ToEntity(this Domain.Gender Gender)
		{
			if (Gender == null)
				throw new ArgumentNullException($"{nameof(Gender)} in Gender Extension !");

			return new DAL.Entities.Gender
			{
				GenderId = Gender.GenderId,
				Name = Gender.Name,
			};
		}
	}
}
