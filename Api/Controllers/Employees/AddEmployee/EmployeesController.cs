using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.EmployeeService;

namespace Api.Controllers.Employees;


public partial class EmployeesController
{
	/// <summary>
	/// Create employee
	/// </summary>
	/// <param name="request">Payload</param>
	/// <returns></returns>
	[HttpPost]
	public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
	{
		return await _employeeBll.AddEmployeeAsync(request.Adapt<AddEmployeeRequestDto>());
	}
}