using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class MatchExtension
	{
		public static Domain.Match ToDomain(this DAL.Entities.Match Match)
		{
			if (Match == null)
				throw new ArgumentNullException($"{nameof(Match)} is empty in Match Extension !");

			return new Domain.Match
			{
				MatchId = Match.MatchId,

				Round = Match.Round,
				Day = Match.Day,
				Date = Match.Date,
				Status = Match.Status,
				Period = Match.Period,
				Time = Match.Time,
				HomeTeamScore = Match.HomeTeamScore,
				VisitorTeamScore = Match.VisitorTeamScore,
				Postseason = Match.Postseason,

				SeasonId = Match.SeasonId,
				
				HomeTeamId = Match.HomeTeamId,
				HomeTeam = Match.HomeTeam?.ToDomain(),

				VisitorTeamId = Match.VisitorTeamId,
				VisitorTeam = Match.VisitorTeam?.ToDomain(),

				Statistics = Match.Statistics?.Select(s => s.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Match ToEntity(this Domain.Match Match)
		{
			if (Match == null)
				throw new ArgumentNullException($"{nameof(Match)} is empty in Match Extension !");

			return new DAL.Entities.Match
			{
				MatchId = Match.MatchId,

				Round = Match.Round,
				Day = Match.Day,
				Date = Match.Date,
				Status = Match.Status,
				Period = Match.Period,
				Time = Match.Time,
				HomeTeamScore = Match.HomeTeamScore,
				VisitorTeamScore = Match.VisitorTeamScore,
				Postseason = Match.Postseason,

				SeasonId = Match.SeasonId,

				HomeTeamId = Match.HomeTeamId,
				VisitorTeamId = Match.VisitorTeamId,

				Statistics = Match.Statistics?.Select(s => s.ToEntity()).ToList()
			};
		}
	}
}
