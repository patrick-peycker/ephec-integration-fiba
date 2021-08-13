using System;

namespace Fiba.DAL.Entities
{
	public class PlayerTeam
	{
		public Player Player { get; set; }
		public int PlayerId { get; set; }

		public Team Team { get; set; }
		public int TeamId { get; set; }

		public DateTime StartOfContract { get; set; }
		public DateTime EndOfContract { get; set; }
	}
}
