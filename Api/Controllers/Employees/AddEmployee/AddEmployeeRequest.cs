using System.ComponentModel.DataAnnotations;
using Api.Controllers.Shared.Validators;

namespace Api.Controllers.Employees;

/// <summary>
/// Request model to create a employee
/// </summary>
public class AddEmployeeRequest
{
	[Required]
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	[Required]
	public string LastName { get; set; }
	[Required]
	[AgeRangeAnnotation(13, 75, ErrorMessage = "Age must be between 13 and 75 years.")]
	public DateOnly Birthdate { get; set; }
}