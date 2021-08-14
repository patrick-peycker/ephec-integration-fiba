using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/teams")]
	[ApiController]
	public class TeamsController : ControllerBase
	{
		private readonly ILogger<TeamsController> logger;
		private readonly IFibaActors fibaActors;

		public TeamsController(ILogger<TeamsController> logger, IFibaActors fibaActors)
		{
			this.logger = logger;
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} is empty in Teams Controller !");
		}


		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Team>> GetTeamsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} is empty in Teams Controller !");

			try
			{
				logger.LogInformation($"Get Teams by gender called...");
				return Ok(fibaActors.GuestActor.GetTeamsByGender(genderId));
			}

			catch (Exception ex)
			{
				var error = "Failed to get teams by gender !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
