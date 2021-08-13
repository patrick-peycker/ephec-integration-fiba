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
	[Route("api/genders/{genderId}/playercollections")]
	[ApiController]
	public class PlayerCollectionsController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public PlayerCollectionsController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in PlayerCollection Controller !");
		}

		[HttpGet("{ids}", Name = "GetPlayerCollectionsByGender")]
		public IActionResult GetPlayerCollectionsByGender(
			Guid genderId,
			[FromRoute]
			[ModelBinder(BinderType = typeof(ArrayModelBinder))]
			IEnumerable<int> ids)
		{
			if (ids == null)
			{
				return BadRequest();
			}

			var Players = fibaActors.AuthenticatedActor.GetPlayersByGender(ids);

			if (ids.Count() != Players.Count())
			{
				return NotFound();
			}

			return Ok(Players);
		}

		[HttpPost]
		public async Task<ActionResult<IEnumerable<Player>>> AddPlayerCollectionsByGender(Guid genderId)
		{
			if (genderId == null)
				throw new ArgumentNullException($"{nameof(genderId)} in Players Repository");

			if (!fibaActors.AuthenticatedActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			List<Player> PlayersToCreate = new List<Player>();

			IEnumerable<Player> Players = await fibaActors.AuthenticatedActor.AddPlayersByGenderAsync(genderId, PlayersToCreate);

			var idsAsString = string.Join(",", Players.Select(t => t.PlayerId));

			return CreatedAtRoute("GetPlayerCollectionsByGender", new { genderId = genderId, ids = idsAsString }, Players);
		}
	}
}
