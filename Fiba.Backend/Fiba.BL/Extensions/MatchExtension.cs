﻿using System;
using System.Linq;

namespace Fiba.BL.Extensions
{
	public static class MatchExtension
	{
		public static Domain.Match ToDomain(this DAL.Entities.Match Match)
		{
			if (Match == null)
				throw new ArgumentNullException($"{nameof(Match)} in Round Extension !");

			return new Domain.Match
			{
				MatchId = Match.MatchId,
				Status = Match.Status,
				Date = Match.Date,
				Period = Match.Period,
				Time = Match.Time,
				HomeTeamScore = Match.HomeTeamScore,
				VisitorTeamScore = Match.VisitorTeamScore,

				SeasonId = Match.HomeTeamSeasonId,
				HomeTeamId = Match.HomeTeam.TeamId,
				VisitorTeamId = Match.VisitorTeam.TeamId,

				Statistics = Match.Statistics?.Select(s => s.ToDomain()).ToList()
			};
		}

		public static DAL.Entities.Match ToEntity(this Domain.Match Match)
		{
			if (Match == null)
				throw new ArgumentNullException($"{nameof(Match)} in Round Extension !");

			return new DAL.Entities.Match
			{
				MatchId = Match.MatchId,
				Status = Match.Status,
				Date = Match.Date,
				Period = Match.Period,
				Time = Match.Time,
				HomeTeamScore = Match.HomeTeamScore,
				VisitorTeamScore = Match.VisitorTeamScore,

				HomeTeamSeasonId = Match.SeasonId,
				HomeTeamId = Match.HomeTeamId,
				VisitorTeamId = Match.VisitorTeamId,

				Statistics = Match.Statistics?.Select(s => s.ToEntity()).ToList()
			};
		}
	}
}
