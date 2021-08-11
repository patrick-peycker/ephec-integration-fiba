using System;
using System.Collections.Generic;

namespace Fiba.BL.Domain
{
	public class SesonTeam
	{
		public int SeasonId { get; set; }
		public int TeamId { get; set; }
		public ICollection<Match> HomeMatches { get; set; }
		public ICollection<Match> AwayMatches { get; set; }
	}
}
