namespace Services.EmployeeService;

public class AddEmployeeResponseDto
{
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public DateOnly Birthdate { get; set; }
}