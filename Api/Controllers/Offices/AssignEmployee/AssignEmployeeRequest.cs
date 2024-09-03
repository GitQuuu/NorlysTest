namespace Api.Controllers.Offices;

/// <summary>
/// Request model
/// </summary>
public class AssignEmployeeRequest
{
	public int EmployeeId { get; set; }
	public int OfficeId	 { get; set; }
}