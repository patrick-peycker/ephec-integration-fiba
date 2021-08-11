using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class TeamPlayer
	{
		[Required]
		public int TeamId { get; set; }
		[Required]
		public int PlayerId { get; set; }

		public ICollection<Statistic> Statistics { get; set; }
	}
}
