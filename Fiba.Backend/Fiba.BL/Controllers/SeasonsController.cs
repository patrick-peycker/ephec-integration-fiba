using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/[controller]")]
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

			if (!fibaActors.GuestActor.DoesGenderExist(genderId))
				return NotFound();

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

		[Authorize]
		[HttpPost]
		public async Task<ActionResult<Season>> AddSeasonForGenderAsync(Guid genderId, Season season)
		{
			if (season == null)
				throw new ArgumentNullException($"{nameof(season)} is empty in Season Controller");

			if (!fibaActors.GuestActor.DoesGenderExist(genderId))
				return NotFound();

			try
			{
				logger.LogInformation($"Get Seanson For Gender called...");
				await fibaActors.AuthenticatedActor.AddSeasonAsync(season);
				return CreatedAtRoute("GetSeasonForGender", new { genderId, seasonId = season.SeasonId }, season);
			}

			catch (Exception ex)
			{
				var error = "Failed to Add Season for Gender !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}

		[Authorize]
		[HttpGet("{seasonId}", Name = "GetSeasonForGender")]
		[HttpHead]
		public async Task<ActionResult<IEnumerable<Season>>> GetSeasonForGenderdAsync(Guid genderId, Guid seasonId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Season Controller !");

			Season season;

			try
			{
				logger.LogInformation($"Get Seanson by Id called...");

				if (!fibaActors.GuestActor.DoesGenderExist(genderId))
					return NotFound();
				
				season = await fibaActors.AuthenticatedActor.GetSeasonForGenderdAsync(genderId, seasonId);
				return Ok(season);
			}

			catch (Exception ex)
			{
				var error = "Failed to Get Season by id !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
