using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Player
	{
		public int PlayerId { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Position { get; set; }

		[Required]
		public Guid GenderId { get; set; }
		
		public ICollection<TeamPlayer> TeamPlayers { get; set; }
	}
}
