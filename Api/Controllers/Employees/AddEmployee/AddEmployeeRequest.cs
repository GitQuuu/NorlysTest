namespace Api.Controllers.Employees;

/// <summary>
/// Request model to create a employee
/// </summary>
public class AddEmployeeRequest
{
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public DateOnly Birthdate { get; set; }
}