using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class SeasonExtension
	{
		public static Domain.Season ToDomain(this DAL.Entities.Season Season)
		{
			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} in Season Extension !");

			return new Domain.Season
			{
				SeasonId = Season.SeasonId,
				Year = Season.Year,
				
				GenderId = Season.GenderId,
				
				SeasonTeam = Season.SeasonsTeams?.Select(s => s.ToDomain()).ToList(),
			};
		}

		public static DAL.Entities.Season ToEntity(this Domain.Season Season)
		{
			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} in Season Extension !");

			return new DAL.Entities.Season
			{
				SeasonId = Season.SeasonId,
				Year = Season.Year,
				
				GenderId = Season.GenderId,

				SeasonsTeams = Season.SeasonTeam?.Select(s => s.ToEntity()).ToList(),
			};
		}
	}
}
