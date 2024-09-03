using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Employees;

public partial class EmployeesController
{
	/// <summary>
	/// Edit employee
	/// </summary>
	/// <param name="request">payload</param>
	/// <returns></returns>
	/// <remarks>Use the Get Employees endpoints first to know the id of each employees</remarks>
	[HttpPatch]
	public async Task<IActionResult> EditEmployee([FromBody] EditEmployeeRequest request)
	{
		return await _employeeBll.EditEmployeeAsync(request.Adapt<EditEmployeeRequestDto>());
	}
}