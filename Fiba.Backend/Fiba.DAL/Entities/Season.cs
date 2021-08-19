using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Season
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid SeasonId { get; set; }

		public int Year { get; set; }

		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<SeasonTeam> SeasonsTeams { get; set; }
		public ICollection<Match> Matches { get; set; }
	}
}

