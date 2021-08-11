using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fiba.BL.Controllers
{
	[Route("api/genders")]
	[ApiController]
	public class GendersController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public GendersController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Gender Controller !");
		}

		[HttpGet]
		[HttpHead]
		public ActionResult<IEnumerable<Gender>> GetGenders()
		{
			return Ok(fibaActors.AdministratorActor.GetGenders());
		}
	}
}
