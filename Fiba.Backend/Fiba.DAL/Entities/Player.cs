using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Player
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int PlayerId { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string Position { get; set; }

		[Required]
		public Guid GenderId { get; set; }
		public Gender Gender { get; set; }

		public ICollection<TeamPlayer> TeamPlayers { get; set; }
	}
}
