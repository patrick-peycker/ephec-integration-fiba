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
		public string Abbreviation { get; set; }
		public string ThumbUrl { get; set; }


		[Required]
		public Guid GenderId { get; set; }

		public ICollection<TeamPlayer> TeamPlayers { get; set; }

		public ICollection<SesonTeam> SeasonTeams { get; set; }
	}
}
