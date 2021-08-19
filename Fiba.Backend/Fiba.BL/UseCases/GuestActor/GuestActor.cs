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
			this.fibaUnitOfWork = fibaUnitOfWork ?? throw new ArgumentNullException($"{nameof(fibaUnitOfWork)} is empty in Guest Actor !");
		}

		public bool DoesGenderExist(Guid genderId)
		{
			return fibaUnitOfWork.GenderRepository.DoesGenderExist(genderId);
		}

		public IEnumerable<Domain.Gender> GetGenders()
		{
			return fibaUnitOfWork.GenderRepository.Retrieve()?.Select(g => g.ToDomain());
		}

		public IEnumerable<Domain.Season> GetSeasonsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Guest Actor !");

			return fibaUnitOfWork.SeasonRepository.RetrieveSeasons(genderId)?.Select(s => s.ToDomain());
		}

		public IEnumerable<Domain.Team> GetTeamsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Guest Actor !");

			return fibaUnitOfWork.TeamRepository.RetrieveTeamsByGender(genderId)?.Select(s => s.ToDomain());
		}

		public IEnumerable<Domain.Player> GetPlayersByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Guest Actor !");

			return fibaUnitOfWork.PlayerRepository.RetrievePlayersByGender(genderId)?.Select(s => s.ToDomain());
		}


		public bool DoesSeasonExist(Guid seasonId)
		{
			return fibaUnitOfWork.SeasonRepository.DoesSeasonExist(seasonId);
		}

		public async Task<Domain.Season> GetSeasonAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in empty Season Controller !");

			DAL.Entities.Season seasonFromRepo = await fibaUnitOfWork.SeasonRepository.RetrieveSeasonByIdAsync(genderId, seasonId);
			return seasonFromRepo?.ToDomain();
		}

		public Domain.Team GetTeam(Guid genderId, int teamId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Domain.Team> GetTeams()
		{
			return fibaUnitOfWork.TeamRepository.Retrieve()?.Select(t => t.ToDomain());
		}

		public IEnumerable<Domain.Match> GetMatchesBySeason(Guid seasonId)
		{
			return fibaUnitOfWork.MatchRepository.RetrieveMatchesBySeason(seasonId)?.Select(m => m.ToDomain());
		}
	}
}
