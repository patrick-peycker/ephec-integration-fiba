using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Season
	{
		public Guid SeasonId { get; set; }

		[Required]
		[Range(2000, 2050)]
		public int Year { get; set; }
	
		[Required]
		public Guid GenderId { get; set; }
		public string Gender { get; set; }

		public List<Match> Matches { get; set; }
		public List<SeasonTeam> SeasonTeams { get; set; }
	}
}
