using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public partial class EmployeeBll
{
	public async Task<IActionResult> AddEmployeeAsync(AddEmployeeRequestDto request)
	{
		var response = await _employeeService.CreateEmployeeAsync(request);
		
		return await _responseService.HandleResultAsync(response);
	}
}