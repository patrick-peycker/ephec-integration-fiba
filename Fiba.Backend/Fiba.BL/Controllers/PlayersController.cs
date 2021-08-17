using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/players")]
	[ApiController]
	public class PlayersController : ControllerBase
	{
		private readonly ILogger<PlayersController> logger;
		private readonly IFibaActors fibaActors;

		public PlayersController(ILogger<PlayersController> logger, IFibaActors fibaActors)
		{
			this.logger = logger;
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} is empty in Players Controller !");
		}


		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Player>> GetPlayersByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Players Controller !");

			if (!fibaActors.GuestActor.DoesGenderExist(genderId))
				return NotFound();

			try
			{
				logger.LogInformation($"Get Players by Gender called...");
				return Ok(fibaActors.GuestActor.GetPlayersByGender(genderId));
			}

			catch (Exception ex)
			{
				var error = "Failed to Get Players by Gender !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
