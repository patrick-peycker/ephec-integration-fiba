using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class TeamPlayerExtension
	{
		public static Domain.TeamPlayer ToDomain(this DAL.Entities.TeamPlayer TeamPlayer)
		{
			if (TeamPlayer == null)
				throw new ArgumentNullException($"{nameof(TeamPlayer)} in TeamPlayer Extension !");

			return new Domain.TeamPlayer
			{
				PlayerId = TeamPlayer.PlayerId,
				
				TeamId = TeamPlayer.TeamId,

				Statistics = TeamPlayer.Statistics?.Select(tp=>tp.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.TeamPlayer ToEntity(this Domain.TeamPlayer TeamPlayer)
		{
			if (TeamPlayer == null)
				throw new ArgumentNullException($"{nameof(TeamPlayer)} in TeamPlayer Extension !");

			return new DAL.Entities.TeamPlayer
			{
				PlayerId = TeamPlayer.PlayerId,
				
				TeamId = TeamPlayer.TeamId,

				Statistics = TeamPlayer.Statistics?.Select(tp => tp.ToEntity()).ToList()
			};
		}
	}
}
