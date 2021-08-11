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
	[Route("api/genders/{genderId}/teamcollections")]
	[ApiController]
	public class TeamCollectionsController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public TeamCollectionsController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in TeamCollection Controller !");
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

			var teams = fibaActors.SuperAdministratorActor.GetTeamsByGender(ids);

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

			if (!fibaActors.AdministratorActor.IsGenderExist(genderId))
			{
				return NotFound();
			}

			List<Team> teamsToCreate = new List<Team>();

			using (var client = new HttpClient())
			{
				var httpResponse = await client.GetAsync("http://www.balldontlie.io/api/v1/teams");

				if (!httpResponse.IsSuccessStatusCode)
				{
					Console.WriteLine($"Status Code : {httpResponse.StatusCode}");
				}

				var content = JsonConvert.DeserializeObject<dynamic>(await httpResponse.Content.ReadAsStringAsync());

				foreach (var item in content.data)
				{
					var team = new Team();
					team.TeamId = item["id"];
					team.City = item["city"];
					team.Name = item["full_name"];

					teamsToCreate.Add(team);
				}
			}

			IEnumerable<Team> teams = await fibaActors.SuperAdministratorActor.AddTeamsByGenderAsync(genderId, teamsToCreate);

			var idsAsString = string.Join(",", teams.Select(t => t.TeamId));

			return CreatedAtRoute("GetTeamCollectionsByGender", new { genderId = genderId, ids = idsAsString }, teams);
		}
	}
}
