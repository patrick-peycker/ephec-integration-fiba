using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Player
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PlayerId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Position { get; set; }

		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<PlayerTeam> PlayersTeams { get; set; }
		public ICollection<Statistic> Statistics { get; set; }
	}
}
