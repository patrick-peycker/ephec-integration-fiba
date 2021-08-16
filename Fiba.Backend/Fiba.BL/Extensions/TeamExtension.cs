using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class TeamExtension
	{
		public static Domain.Team ToDomain(this DAL.Entities.Team Team)
		{
			if (Team == null)
				throw new ArgumentNullException($"{nameof(Team)} is empty in Team Extension !");

			return new Domain.Team
			{
				TeamId = Team.TeamId,

				Name = Team.Name,
				City = Team.City,
				Abbreviation = Team.Abbreviation,
				ThumbUrl = Team.ThumbUrl,

				GenderId = Team.GenderId,
				Gender = Team.Gender?.Name,

				//PlayersTeams = Team.PlayersTeams?.Select(tp => tp.ToDomain()).ToList(),
				//SeasonsTeams = Team.SeasonsTeams?.Select(st => st.ToDomain()).ToList(),
				//HomeMatches = Team.HomeMatches?.Select(m => m.ToDomain()).ToList(),
				//AwayMatches = Team.AwayMatches?.Select(m => m.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Team ToEntity(this Domain.Team Team)
		{
			if (Team == null)
				throw new ArgumentNullException($"{nameof(Team)} is empty in Team Extension !");

			return new DAL.Entities.Team
			{
				TeamId = Team.TeamId,

				Name = Team.Name,
				City = Team.City,
				Abbreviation = Team.Abbreviation,
				ThumbUrl = Team.ThumbUrl,

				GenderId = Team.GenderId,

				//PlayersTeams = Team.PlayersTeams?.Select(tp => tp.ToEntity()).ToList(),
				//SeasonsTeams = Team.SeasonsTeams?.Select(st => st.ToEntity()).ToList(),
				//AwayMatches = Team.AwayMatches?.Select(m => m.ToEntity()).ToList()
			};
		}
	}
}

