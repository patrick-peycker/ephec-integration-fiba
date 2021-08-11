using System.ComponentModel.DataAnnotations;

namespace Fiba.BL.ValidationAttributes
{
	public class NbTeamsMustBePairAndBetween2And20 : ValidationAttribute
	{
		//protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		//{
		//	var season = (Domain.Season)validationContext.ObjectInstance;

		//	if (!(season.NbTeams % 2 == 0 && season.NbTeams >= 2 && season.NbTeams <= 20))
		//	{
		//		return new ValidationResult("The number of teams must be even and between 2 and 20", new[] { nameof(Domain.Season) });
		//	}
		//	return ValidationResult.Success;
		//}
	}
}
