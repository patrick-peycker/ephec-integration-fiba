using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class SeasonTeamsExtension
	{
		public static Domain.SeasonTeam ToDomain(this DAL.Entities.SeasonTeam SeasonTeam)
		{
			if (SeasonTeam == null)
				throw new ArgumentNullException($"{nameof(SeasonTeam)} in SeasonTeamMatch Extension !");

			return new Domain.SeasonTeam
			{
				SeasonId = SeasonTeam.SeasonId,
				TeamId = SeasonTeam.TeamId,
			};
		}

		public static DAL.Entities.SeasonTeam ToEntity(this Domain.SeasonTeam SeasonTeam)
		{
			if (SeasonTeam == null)
				throw new ArgumentNullException($"{nameof(SeasonTeam)} in SeasonTeamMatch Extension !");

			return new DAL.Entities.SeasonTeam
			{
				SeasonId = SeasonTeam.SeasonId,
				TeamId = SeasonTeam.TeamId,
			};
		}
	}
}
