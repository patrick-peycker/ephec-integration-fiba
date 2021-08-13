using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Teams Controller !");
		}


		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Team>> GetTeams()
		{
			try
			{
				logger.LogInformation($"Get Teams called...");
				return Ok(fibaActors.GuestActor.GetTeams());
			}
			catch (Exception ex)
			{
				var error = "Failed to get teams !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
