using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class SeasonExtension
	{
		public static Domain.Season ToDomain(this DAL.Entities.Season Season)
		{
			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} is empty in Season Extension !");

			return new Domain.Season
			{
				SeasonId = Season.SeasonId,

				Year = Season.Year,
				GenderId = Season.GenderId,
				Gender = Season.Gender?.Name,
				
				SeasonTeams = Season.SeasonsTeams?.Select(s => s.ToDomain()).ToList(),
				Matches = Season.Matches?.Select(s=> s.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Season ToEntity(this Domain.Season Season)
		{
			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} is empty in Season Extension !");

			return new DAL.Entities.Season
			{
				SeasonId = Season.SeasonId,

				Year = Season.Year,
				GenderId = Season.GenderId,

				SeasonsTeams = Season.SeasonTeams?.Select(s => s.ToEntity()).ToList(),
				Matches = Season.Matches?.Select(s => s.ToEntity()).ToList()
			};
		}
	}
}
