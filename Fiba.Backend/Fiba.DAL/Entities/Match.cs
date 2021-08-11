using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Match
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int MatchId { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public DateTimeOffset Date { get; set; }
		public int Period { get; set; }
		public DateTime Time { get; set; }
		public int HomeTeamScore { get; set; }
		public int VisitorTeamScore { get; set; }

		public int HomeTeamSeasonId { get; set; }
		public int HomeTeamId { get; set; }
		public SeasonTeam HomeTeam { get; set; }

		public int VisitorTeamSeasonId { get; set; }
		public int VisitorTeamId { get; set; }
		public SeasonTeam VisitorTeam { get; set; }

		public ICollection<Statistic> Statistics { get; set; }
	}
}
