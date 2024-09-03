using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public partial class EmployeeBll
{
	public async Task<IActionResult> EditEmployeeAsync(EditEmployeeRequestDto request)
	{
		var response = await _employeeService.UpdateEmployeeAsync(request);
		return await _responseService.HandleResultAsync(response);
	}
}