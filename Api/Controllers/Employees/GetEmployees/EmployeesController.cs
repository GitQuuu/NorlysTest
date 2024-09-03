using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Employees;

public partial class EmployeesController
{
	/// <summary>
	/// Get a list of employees
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public async Task<IActionResult> GetEmployees()
	{
		return await _employeeBll.GetEmployeesAsync();
	}
}	