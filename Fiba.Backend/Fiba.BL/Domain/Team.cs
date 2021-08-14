using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Team
	{
		public int TeamId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
		[Required]
		[MaxLength(50)]
		public string City { get; set; }
		[Required]
		[MaxLength(3)]
		public string Abbreviation { get; set; }
		public string ThumbUrl { get; set; }


		public Guid GenderId { get; set; }
		public string Gender { get; set; }

		public ICollection<PlayerTeam> PlayersTeams { get; set; }
		public ICollection<SeasonTeam> SeasonsTeams { get; set; }
		public ICollection<Match> HomeMatches { get; set; }
		public ICollection<Match> AwayMatches { get; set; }
		public ICollection<Statistic> Statistics { get; set; }
	}
}
