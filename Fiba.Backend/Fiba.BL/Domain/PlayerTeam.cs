using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class PlayerTeam
	{
		public Player Player { get; set; }
		[Required]
		public int PlayerId { get; set; }

		public Team Team { get; set; }
		[Required]
		public int TeamId { get; set; }

		public DateTime StartOfContract { get; set; }
		public DateTime EndOfContract { get; set; }
	}
}
