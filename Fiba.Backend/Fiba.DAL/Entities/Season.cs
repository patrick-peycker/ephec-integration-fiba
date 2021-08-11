using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Season
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SeasonId { get; set; }

		[Required]
		[Range(2000, 2050)]
		public int Year { get; set; }
		
		[Required]
		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<SeasonTeam> SeasonTeams { get; set; }
	}
}

