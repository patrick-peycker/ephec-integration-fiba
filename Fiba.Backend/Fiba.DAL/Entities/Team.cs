using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Team
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TeamId { get; set; }

		public string Name { get; set; }
		public string City { get; set; }
		public string Abbreviation { get; set; }
		public string ThumbUrl { get; set; }

		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<PlayerTeam> PlayersTeams { get; set; }
		public ICollection<SeasonTeam> SeasonsTeams { get; set; }

		public ICollection<Match> HomeMatches { get; set; }
		public ICollection<Match> AwayMatches { get; set; }
		public ICollection<Statistic> Statistics { get; set; }
	}
}
