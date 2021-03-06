using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Match
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int MatchId { get; set; }

		public int Round { get; set; }
		public int Day { get; set; }
		public DateTime Date { get; set; }
		public int HomeTeamScore { get; set; }
		public int Period { get; set; }
		public string Status { get; set; }
		public DateTime Time { get; set; }
		public int VisitorTeamScore { get; set; }
		public bool Postseason { get; set; }

		public Season Season { get; set; }
		public Guid SeasonId { get; set; }

		public Team HomeTeam { get; set; }
		public int HomeTeamId { get; set; }
	
		public Team VisitorTeam { get; set; }
		public int VisitorTeamId { get; set; }
	
		public ICollection<Statistic> Statistics { get; set; }
	}
}
