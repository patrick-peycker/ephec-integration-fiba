using System;
using System.Collections.Generic;

namespace Fiba.DAL.Entities
{
	public class Season
	{
		public Guid SeasonId { get; set; }

		public int Year { get; set; }

		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<SeasonTeam> SeasonsTeams { get; set; }
	}
}

