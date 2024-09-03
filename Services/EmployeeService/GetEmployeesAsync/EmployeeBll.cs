using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public partial class EmployeeBll
{
	public async Task<IActionResult> GetEmployeesAsync()
	{
		var response = await _employeeService.ReadEmployeesAsync();
		return await _responseService.HandleResultAsync(response);
	}
}