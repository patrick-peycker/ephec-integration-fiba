using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Fiba.BL.Controllers
{
	[Route("api/genders")]
	[ApiController]
	public class GendersController : ControllerBase
	{
		private readonly ILogger logger;
		private readonly IFibaActors fibaActors;

		public GendersController(ILogger logger, IFibaActors fibaActors)
		{
			this.logger = logger;
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Gender Controller !");
		}

		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Gender>> GetGenders()
		{
			try
			{
				logger.LogInformation($"Get Genders called...");
				return Ok(fibaActors.GuestActor.GetGenders());
			}

			catch (Exception ex)
			{
				var error = "Failed to get genders !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
