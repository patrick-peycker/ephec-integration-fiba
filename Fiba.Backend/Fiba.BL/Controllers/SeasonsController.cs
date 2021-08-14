using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/seasons")]
	[ApiController]
	public class SeasonsController : ControllerBase
	{
		private readonly ILogger logger;
		private readonly IFibaActors fibaActors;

		public SeasonsController(ILogger<SeasonsController> logger, IFibaActors fibaActors)
		{
			this.logger = logger;
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} is empty in Season Controller !");
		}

		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Season>> GetSeasonsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Season Controller !");

			try
			{
				logger.LogInformation($"Get Seansons by Gender called...");
				return Ok(fibaActors.GuestActor.GetSeasonsByGender(genderId));
			}

			catch (Exception ex)
			{
				var error = "Failed to Get Seansons by Gender !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}

		[HttpGet("{seasonId}", Name = "GetSeason")]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<Season>>> GetSeasonByIdAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Season Controller !");

			Season season;

			try
			{
				logger.LogInformation($"Get Seanson by Id called...");
				season = await fibaActors.GuestActor.GetSeasonByIdAsync(genderId, seasonId);

				if (season == null)
					return NotFound();

				return Ok(season);
			}

			catch (Exception ex)
			{
				var error = "Failed to Get Season by id !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}


		[HttpPost]
		public async Task<IActionResult> AddSeasonForGender(Guid genderId, Domain.Season Season)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Season Controller !");

			if (Season == null)
				throw new ArgumentNullException($"{nameof(Season)} in Season Controller");

			if (!fibaActors.AuthenticatedActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			Season = await fibaActors.AuthenticatedActor.AddSeasonByGenderAsync(genderId, Season);

			return CreatedAtRoute("GetSeason", new { genderId, seasonId = Season.SeasonId }, Season);
		}
	}
}
