using Api.Controllers.Shared.Validators;

namespace Api.Controllers.Employees;

/// <summary>
/// Request model to edit employee
/// </summary>
public class EditEmployeeRequest
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	[AgeRangeAnnotation(13,75)]
	public DateOnly Birthdate { get; set; }
}