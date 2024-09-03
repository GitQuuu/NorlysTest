using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public partial class EmployeeBll
{
	public async Task<IActionResult> GetEmployeeAsync(int id)
	{
		var response = await _employeeService.ReadEmployeeAsync(id);
		return await _responseService.HandleResultAsync(response);
	}
}