using Fiba.BL.Domain;
using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiba.BL.Controllers
{
	[Route("api/genders/{genderId}/teams")]
	[ApiController]
	public class TeamsController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public TeamsController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Teams Controller !");
		}


	}
}
