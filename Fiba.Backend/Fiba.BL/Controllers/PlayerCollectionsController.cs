using Fiba.BL.Domain;
using Fiba.BL.Helpers;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

			var Players = fibaActors.SuperAdministratorActor.GetPlayersByGender(ids);

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

			if (!fibaActors.AdministratorActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			List<Player> PlayersToCreate = new List<Player>();

			int nbPages = 1;

			using (var client = new HttpClient())
			{
				for (int page = 1; page <= nbPages; page++)
				{
					var httpResponse = await client.GetAsync("http://www.balldontlie.io/api/v1/players?per_page=100&page={page}");

					if (!httpResponse.IsSuccessStatusCode)
					{
						Console.WriteLine($"Status Code : {httpResponse.StatusCode}");
					}

					var content = JsonConvert.DeserializeObject<dynamic>(await httpResponse.Content.ReadAsStringAsync());

					nbPages = content["meta"]["total_pages"];

					foreach (var item in content.data)
					{
						var Player = new Player();
						Player.PlayerId = item["id"];
						Player.FirstName = item["first_name"];
						Player.LastName = item["last_name"];
						Player.Position = item["position"];
						Player.TeamPlayers.Add(new TeamPlayer { PlayerId = Player.PlayerId, TeamId = item["team"]["id"] });

						PlayersToCreate.Add(Player);
					}
				}
			}

			IEnumerable<Player> Players = await fibaActors.SuperAdministratorActor.AddPlayersByGenderAsync(genderId, PlayersToCreate);

			var idsAsString = string.Join(",", Players.Select(t => t.PlayerId));

			return CreatedAtRoute("GetPlayerCollectionsByGender", new { genderId = genderId, ids = idsAsString }, Players);
		}
	}
}
