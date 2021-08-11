using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class SeasonTeamExtension
	{
		public static Domain.SesonTeam ToDomain(this DAL.Entities.SeasonTeam SeasonTeam)
		{
			if (SeasonTeam == null)
				throw new ArgumentNullException($"{nameof(SeasonTeam)} in SeasonTeamMatch Extension !");

			return new Domain.SesonTeam
			{
				SeasonId = SeasonTeam.SeasonId,
				TeamId = SeasonTeam.TeamId,
				HomeMatches = SeasonTeam.HomeMatches?.Select(m => m.ToDomain()).ToList(),
				AwayMatches = SeasonTeam.AwayMatches?.Select(m => m.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.SeasonTeam ToEntity(this Domain.SesonTeam SeasonTeam)
		{
			if (SeasonTeam == null)
				throw new ArgumentNullException($"{nameof(SeasonTeam)} in SeasonTeamMatch Extension !");

			return new DAL.Entities.SeasonTeam
			{
				SeasonId = SeasonTeam.SeasonId,
				TeamId = SeasonTeam.TeamId,
				AwayMatches = SeasonTeam.AwayMatches?.Select(m => m.ToEntity()).ToList()
			};
		}
	}
}
