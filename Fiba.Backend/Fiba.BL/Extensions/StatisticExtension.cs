using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.Extensions
{
	public static class StatisticExtension
	{
		public static Domain.Statistic ToDomain(this DAL.Entities.Statistic Statistic)
		{
			if (Statistic == null)
				throw new ArgumentNullException($"{nameof(Statistic)} in Round Extension !");

			return new Domain.Statistic
			{
				StatisticId = Statistic.StatisticId,
				Assist = Statistic.Assist,
				Block = Statistic.Block,
				DefensiveRebound = Statistic.DefensiveRebound,
				FieldGoalAttempted = Statistic.FieldGoalAttempted,
				FieldGoalMade = Statistic.FieldGoalMade,
				FieldGoalPourcentage = Statistic.FieldGoalPourcentage,
				FreeTrowAttempted = Statistic.FreeTrowAttempted,
				FreeTrowMade = Statistic.FreeTrowMade,
				FreeTrowPourcentage = Statistic.FreeTrowPourcentage,
				OffensiveRebound = Statistic.OffensiveRebound,
				PersonnalFoul = Statistic.PersonnalFoul,
				Point = Statistic.Point,
				Rebound = Statistic.Rebound,
				Steal = Statistic.Steal,
				ThreePointFieldGoalAttempted = Statistic.ThreePointFieldGoalAttempted,
				ThreePointFieldGoalMade = Statistic.ThreePointFieldGoalMade,
				ThreePointFieldGoalPourcentage = Statistic.ThreePointFieldGoalPourcentage,
				Turnover = Statistic.Turnover,

				MatchId = Statistic.MatchId,
				PlayerId = Statistic.PlayerId,
				TeamId = Statistic.TeamId
			};
		}

		public static DAL.Entities.Statistic ToEntity(this Domain.Statistic Statistic)
		{
			if (Statistic == null)
				throw new ArgumentNullException($"{nameof(Statistic)} in Round Extension !");

			return new DAL.Entities.Statistic
			{
				StatisticId = Statistic.StatisticId,
				Assist = Statistic.Assist,
				Block = Statistic.Block,
				DefensiveRebound = Statistic.DefensiveRebound,
				FieldGoalAttempted = Statistic.FieldGoalAttempted,
				FieldGoalMade = Statistic.FieldGoalMade,
				FieldGoalPourcentage = Statistic.FieldGoalPourcentage,
				FreeTrowAttempted = Statistic.FreeTrowAttempted,
				FreeTrowMade = Statistic.FreeTrowMade,
				FreeTrowPourcentage = Statistic.FreeTrowPourcentage,
				OffensiveRebound = Statistic.OffensiveRebound,
				PersonnalFoul = Statistic.PersonnalFoul,
				Point = Statistic.Point,
				Rebound = Statistic.Rebound,
				Steal = Statistic.Steal,
				ThreePointFieldGoalAttempted = Statistic.ThreePointFieldGoalAttempted,
				ThreePointFieldGoalMade = Statistic.ThreePointFieldGoalMade,
				ThreePointFieldGoalPourcentage = Statistic.ThreePointFieldGoalPourcentage,
				Turnover = Statistic.Turnover,
				
				MatchId = Statistic.MatchId,
				PlayerId = Statistic.PlayerId,
				TeamId = Statistic.TeamId
			};
		}
	}
}
