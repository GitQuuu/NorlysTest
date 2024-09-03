using Microsoft.AspNetCore.Mvc;

namespace Services.EmployeeService;

public partial class EmployeeBll
{
	public async Task<IActionResult> RemoveEmployeeAsync(int id)
	{
		var response = await _employeeService.DeleteAsync(id);
		return await _responseService.HandleResultAsync(response);
	}
}