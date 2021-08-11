﻿using Fiba.BL.Domain;
using Fiba.BL.Extensions;
using Fiba.BL.Interfaces;
using Fiba.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.UseCases.Guest
{
	public class GuestActor : IGuestActor
	{
		private readonly IFibaUnitOfWork fibaUnitOfWork;

		public GuestActor(IFibaUnitOfWork fibaUnitOfWork)
		{
			this.fibaUnitOfWork = fibaUnitOfWork ?? throw new ArgumentNullException($"{nameof(fibaUnitOfWork)} in Guest Actor !");
		}

		public async Task<Season> GetSeasonAsync(Guid genderId, int seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			DAL.Entities.Season seasonFromRepo = await fibaUnitOfWork.SeasonRepository.RetrieveSeasonAsync(genderId, seasonId);
			return seasonFromRepo?.ToDomain();
		}

		public IEnumerable<Season> GetSeasonsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			return fibaUnitOfWork.SeasonRepository.RetrieveSeasons(genderId)?.Select(s=>s.ToDomain());
		}

		public Team GetTeam(Guid genderId, int teamId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Team> GetTeamsByGender(Guid genderId)
		{
			throw new NotImplementedException();
		}
	}
}
