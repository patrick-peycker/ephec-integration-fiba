using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.Domain
{
	public class Gender
	{
		public Guid GenderId { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
