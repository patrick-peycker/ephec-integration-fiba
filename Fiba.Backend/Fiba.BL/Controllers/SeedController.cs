using Fiba.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fiba.BL.Controllers
{
	[Route("api/seed")]
	[ApiController]
	public class SeedController : ControllerBase
	{
		private readonly IFibaActors fibaActors;

		public SeedController(IFibaActors fibaActors)
		{
			this.fibaActors = fibaActors ?? throw new ArgumentNullException($"{nameof(fibaActors)} in Gender Controller !");
		}



	}
}
