using Fiba.BL.Domain;
using Fiba.BL.Helpers;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/teamcollections")]
	[ApiController]
	public class TeamCollectionsController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public TeamCollectionsController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} is empty in TeamCollection Controller !");
		}

		[HttpGet("{ids}", Name = "GetTeamCollectionsByGender")]
		public IActionResult GetTeamCollectionsByGender(
			Guid genderId,
			[FromRoute]
			[ModelBinder(BinderType = typeof(ArrayModelBinder))]
			IEnumerable<int> ids)
		{
			if (ids == null)
			{
				return BadRequest();
			}

			var teams = fibaActors.AuthenticatedActor.GetTeamsByGender(ids);

			if (ids.Count() != teams.Count())
			{
				return NotFound();
			}

			return Ok(teams);
		}

		[HttpPost]
		public async Task<ActionResult<IEnumerable<Team>>> AddTeamCollectionsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Teams Repository");

			if (!fibaActors.AuthenticatedActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			List<Team> teamsToCreate = new List<Team>();

			IEnumerable<Team> teams = await fibaActors.AuthenticatedActor.AddTeamsByGenderAsync(genderId, teamsToCreate);

			var idsAsString = string.Join(",", teams.Select(t => t.TeamId));

			return CreatedAtRoute("GetTeamCollectionsByGender", new { genderId = genderId, ids = idsAsString }, teams);
		}
	}
}
