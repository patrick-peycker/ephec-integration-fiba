using System.Collections.Generic;

namespace Fiba.DAL.Entities
{
	public class TeamPlayer
	{
		public Team Team { get; set; }
		public int TeamId { get; set; }

		public Player Player { get; set; }
		public int PlayerId { get; set; }

		public ICollection<Statistic> Statistics { get; set; }
	}
}