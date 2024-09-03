using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.EmployeeService;

namespace Api.Controllers.Employees;

/// <summary>
/// Create a employee
/// </summary>
public partial class EmployeesControllers
{
	[HttpPost]
	public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
	{
		return await _employeeBll.AddEmployeeAsync(request.Adapt<AddEmployeeRequestDto>());
	}
}