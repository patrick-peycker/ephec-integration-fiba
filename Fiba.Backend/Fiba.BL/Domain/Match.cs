using Fiba.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Match
	{
		public int MatchId { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public DateTimeOffset Date { get; set; }
		public int Period { get; set; }
		public DateTime Time { get; set; }
		public int HomeTeamScore { get; set; }
		public int VisitorTeamScore { get; set; }

		public int SeasonId { get; set; }
		public int HomeTeamId { get; set; }
		public int VisitorTeamId { get; set; }

		public ICollection<Statistic> Statistics { get; set; }
	}
}
