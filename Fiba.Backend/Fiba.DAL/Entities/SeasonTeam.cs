using System.Collections.Generic;

namespace Fiba.DAL.Entities
{
	public class SeasonTeam
	{
		public Season Season { get; set; }
		public int SeasonId { get; set; }

		public Team Team { get; set; }
		public int TeamId { get; set; }

		public ICollection<Match> HomeMatches { get; set; }
		public ICollection<Match> AwayMatches { get; set; }
	}
}
