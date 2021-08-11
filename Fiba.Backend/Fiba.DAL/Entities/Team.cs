using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Team
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
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

		public ICollection<SeasonTeam> SeasonTeams { get; set; }
	}
}
