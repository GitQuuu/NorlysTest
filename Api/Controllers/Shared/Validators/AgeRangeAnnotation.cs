using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Shared.Validators;

/// <summary>
/// Custom validator used as DataAnnotation in the request model
/// </summary>
public class AgeRangeAnnotation : ValidationAttribute
{
	private int MinAge { get; set; }
	private int MaxAge { get; set; }
	
	public AgeRangeAnnotation(int minAge, int maxAge)
	{
		MinAge = minAge;
		MaxAge = maxAge;
	}
	
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is not DateOnly birthdate)
		{
			return new ValidationResult("Invalid date format.");
		}

		var today = DateOnly.FromDateTime(DateTime.Today);
		var age   = today.Year - birthdate.Year;
		
		if (birthdate > today.AddYears(-age))
		{
			age--;
		}

		if (age < MinAge || age > MaxAge)
		{
			return new ValidationResult($"Age must be between {MinAge} and {MaxAge} years.");
		}

		return ValidationResult.Success;
	}
}