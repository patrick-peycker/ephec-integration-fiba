using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/seasons")]
	[ApiController]
	public class SeasonsController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public SeasonsController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Season Controller !");
		}

		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Domain.Season>> GetSeasonsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			return Ok(fibaActors.GuestActor.GetSeasonsByGender(genderId));
		}

		[HttpGet("{seasonId}", Name = "GetSeason")]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<Domain.Season>>> GetSeasonAsync(Guid genderId, int seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			var season = await fibaActors.GuestActor.GetSeasonAsync(genderId, seasonId);

			if (season == null)
				return NotFound();

			return Ok(season);
		}


		[HttpPost]
		public async Task<IActionResult> AddSeasonForGender(Guid genderId, Domain.Season Season)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} in Season Controller");

			if (!fibaActors.AdministratorActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			Season = await fibaActors.AdministratorActor.AddSeasonByGenderAsync(genderId, Season);

			return CreatedAtRoute("GetSeason", new { genderId, seasonId = Season.SeasonId }, Season);
		}
	}
}
