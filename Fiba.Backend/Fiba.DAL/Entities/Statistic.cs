using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiba.DAL.Entities
{
	public class Statistic 
	{ 
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int StatisticId { get; set; }

		public int Assist { get; set; }
		public int Block { get; set; }
		public int DefensiveRebound { get; set; }
		public decimal ThreePointsFieldGoalPourcentage { get; set; }
		public int ThreePointsFieldGoalAttempted { get; set; }
		public int ThreePointsFieldGoalMade { get; set; }
		public decimal FieldGoalPourcentage { get; set; }
		public int FieldGoalAttempted { get; set; }
		public int FieldGoalMade { get; set; }
		public decimal FreeTrowPourcentage { get; set; }
		public int FreeTrowAttempted { get; set; }
		public int FreeTrowMade { get; set; }
		public DateTime Minutes { get; set; }
		public int OffensiveRebound { get; set; }
		public int PersonnalFoul { get; set; }
		public int Points { get; set; }
		public int Rebound { get; set; }
		public int Steal { get; set; }
		public int Turnover { get; set; }

		public Team Team { get; set; }
		public int TeamId { get; set; }

		public Player Player { get; set; }
		public int PlayerId { get; set; }

		public Match Match { get; set; }
		public int MatchId { get; set; }
	}
}
