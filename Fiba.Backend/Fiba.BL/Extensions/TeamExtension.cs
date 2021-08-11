using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class TeamExtension
	{
		public static Domain.Team ToDomain(this DAL.Entities.Team Team)
		{
			if (Team == null)
				throw new ArgumentNullException($"{nameof(Team)} in Team Extension !");

			return new Domain.Team
			{
				TeamId = Team.TeamId,
				Name = Team.Name,
				City = Team.City,
				Abbreviation = Team.Abbreviation,
				ThumbUrl = Team.ThumbUrl,

				GenderId = Team.GenderId,

				TeamPlayers = Team.TeamPlayers?.Select(tp => tp.ToDomain()).ToList(),

				SeasonTeams = Team.SeasonTeams?.Select(st => st.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Team ToEntity(this Domain.Team Team)
		{
			if (Team == null)
				throw new ArgumentNullException($"{nameof(Team)} in Team Extension !");

			return new DAL.Entities.Team
			{
				TeamId = Team.TeamId,
				Name = Team.Name,
				City = Team.City,
				Abbreviation = Team.Abbreviation,
				ThumbUrl = Team.ThumbUrl,

				GenderId = Team.GenderId,

				TeamPlayers = Team.TeamPlayers?.Select(tp => tp.ToEntity()).ToList(),

				SeasonTeams = Team.SeasonTeams?.Select(st => st.ToEntity()).ToList()
			};
		}
	}
}

