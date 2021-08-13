using System;

namespace Fiba.DAL.Entities
{
	public class SeasonTeam
	{
		public Season Season { get; set; }
		public Guid SeasonId { get; set; }

		public Team Team { get; set; }
		public int TeamId { get; set; }
	}
}
