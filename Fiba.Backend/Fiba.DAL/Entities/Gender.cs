using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.DAL.Entities
{
	public class Gender
	{
		public Guid GenderId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public ICollection<Season> Seasons { get; set; }
		public ICollection<Team> Teams { get; set; }
		public ICollection<Player> Players { get; set; }
	}
}
