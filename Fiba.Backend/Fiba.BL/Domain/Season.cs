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

		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		[Required]
		public ICollection<SeasonTeam> SeasonTeam { get; set; }
	}
}
