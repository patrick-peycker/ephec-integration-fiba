using Fiba.BL.Domain;
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

		public IEnumerable<Gender> GetGenders()
		{
			IEnumerable<DAL.Entities.Gender> gendersFromRepo = fibaUnitOfWork.GenderRepository.Retrieve();
			return gendersFromRepo?.Select(g => g.ToDomain());
		}

		public IEnumerable<Season> GetSeasonsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Guest Actor !");

			return fibaUnitOfWork.SeasonRepository.RetrieveSeasonsByGender(genderId)?.Select(s => s.ToDomain());
		}

		public async Task<Season> GetSeasonAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			DAL.Entities.Season seasonFromRepo = await fibaUnitOfWork.SeasonRepository.RetrieveSeasonAsync(genderId, seasonId);
			return seasonFromRepo?.ToDomain();
		}

		public Team GetTeam(Guid genderId, int teamId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Team> GetTeams()
		{
			return fibaUnitOfWork.TeamRepository.Retrieve().Select(t => t.ToDomain());
		}

		public IEnumerable<Team> GetTeamsByGender(Guid genderId)
		{
			throw new NotImplementedException();
		}
	}
}
