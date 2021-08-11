namespace Fiba.BL.Domain
{
	public class Statistic
	{
		public int StatisticId { get; set; }
		public int Assist { get; set; }
		public int Block { get; set; }
		public int DefensiveRebound { get; set; }
		public decimal ThreePointFieldGoalPourcentage { get; set; }
		public int ThreePointFieldGoalAttempted { get; set; }
		public int ThreePointFieldGoalMade { get; set; }
		public decimal FieldGoalPourcentage { get; set; }
		public int FieldGoalAttempted { get; set; }
		public int FieldGoalMade { get; set; }
		public decimal FreeTrowPourcentage { get; set; }
		public int FreeTrowAttempted { get; set; }
		public int FreeTrowMade { get; set; }
		public int OffensiveRebound { get; set; }
		public int PersonnalFoul { get; set; }
		public int Point { get; set; }
		public int Rebound { get; set; }
		public int Steal { get; set; }
		public int Turnover { get; set; }

		public int MatchId { get; set; }

		public int PlayerId { get; set; }
		public int TeamId { get; set; }
	}
}
