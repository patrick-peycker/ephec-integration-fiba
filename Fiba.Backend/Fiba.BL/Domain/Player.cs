using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Player
	{
		public int PlayerId { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }
		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }
		[Required]
		[MaxLength(3)]
		public string Position { get; set; }

		[Required]
		public Guid GenderId { get; set; }
		public string Gender { get; set; }

		public ICollection<PlayerTeam> PlayersTeams { get; set; }
		public ICollection<Statistic> Statistics { get; set; }
	}
}
