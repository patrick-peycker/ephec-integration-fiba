using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Season
	{
		public int SeasonId { get; set; }

		[Required]
		[Range(2000, 2050)]
		public int Year { get; set; }
		[Required]
		public Guid GenderId { get; set; }

		[Required]
		public ICollection<SesonTeam> SeasonTeam { get; set; }
	}
}
