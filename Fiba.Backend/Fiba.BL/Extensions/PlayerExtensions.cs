using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class PlayerExtensions
	{
		public static Domain.Player ToDomain(this DAL.Entities.Player Player)
		{
			if (Player == null)
				throw new ArgumentNullException($"{nameof(Player)} is empty in Player Extension !");

			return new Domain.Player
			{
				PlayerId = Player.PlayerId,

				FirstName = Player.FirstName,
				LastName = Player.LastName,
				Position = Player.Position,

				GenderId = Player.GenderId,
				Gender = Player.Gender?.Name,

				PlayersTeams = Player.PlayersTeams?.Select(pt => pt.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Player ToEntity(this Domain.Player Player)
		{
			if (Player == null)
				throw new ArgumentNullException($"{nameof(Player)} is empty in Player Extension !");

			return new DAL.Entities.Player
			{
				PlayerId = Player.PlayerId,

				FirstName = Player.FirstName,
				LastName = Player.LastName,
				Position = Player.Position,

				GenderId = Player.GenderId,

				PlayersTeams = Player.PlayersTeams?.Select(tp => tp.ToEntity()).ToList()
			};
		}
	}
}
