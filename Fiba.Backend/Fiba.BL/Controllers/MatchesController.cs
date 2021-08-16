using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/seasons/{seasonId}/matches")]
	[ApiController]
	public class MatchesController : ControllerBase
	{
		private readonly ILogger logger;
		private readonly IFibaActors fibaActors;

		public MatchesController(ILogger<MatchesController> logger, IFibaActors fibaActors)
		{
			this.logger = logger;
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} is empty in Match Controller !");
		}

		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Match>> GetMatchesBySeason(Guid seasonId)
		{
			try
			{
				logger.LogInformation($"Get Matches by SeasonId called...");
				return Ok(fibaActors.GuestActor.GetMatchesBySeason(seasonId));
			}

			catch (Exception ex)
			{
				var error = "Failed to Get Matchs !";
				logger.LogError($"{error} - {ex.Message}");
				return BadRequest(error);
			}
		}
	}
}
