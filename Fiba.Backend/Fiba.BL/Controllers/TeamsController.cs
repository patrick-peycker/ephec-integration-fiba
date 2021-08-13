using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	//[Route("api/genders/{genderId}/teams")]

	[Route("api/teams")]
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
