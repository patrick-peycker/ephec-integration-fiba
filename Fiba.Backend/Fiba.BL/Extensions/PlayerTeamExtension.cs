using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class PlayerTeamExtension
	{
		public static Domain.PlayerTeam ToDomain(this DAL.Entities.PlayerTeam PlayerTeam)
		{
			if (PlayerTeam == null)
				throw new ArgumentNullException($"{nameof(PlayerTeam)} in TeamPlayer Extension !");

			return new Domain.PlayerTeam
			{
				PlayerId = PlayerTeam.PlayerId,
				
				TeamId = PlayerTeam.TeamId,
			};
		}

		public static DAL.Entities.PlayerTeam ToEntity(this Domain.PlayerTeam PlayerTeam)
		{
			if (PlayerTeam == null)
				throw new ArgumentNullException($"{nameof(PlayerTeam)} in TeamPlayer Extension !");

			return new DAL.Entities.PlayerTeam
			{
				PlayerId = PlayerTeam.PlayerId,
				
				TeamId = PlayerTeam.TeamId,
			};
		}
	}
}
