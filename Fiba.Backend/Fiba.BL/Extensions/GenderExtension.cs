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

				Seasons = Gender.Seasons?.Select(s => s.ToDomain()).ToList(),
				Teams = Gender.Teams?.Select(t => t.ToDomain()).ToList(),
				Players = Gender.Players?.Select(p => p.ToDomain()).ToList()
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

				Seasons = Gender.Seasons?.Select(s => s.ToEntity()).ToList(),
				Teams = Gender.Teams?.Select(t => t.ToEntity()).ToList(),
				Players = Gender.Players?.Select(p => p.ToEntity()).ToList()
			};
		}
	}
}
