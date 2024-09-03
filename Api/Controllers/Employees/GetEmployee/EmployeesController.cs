using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Employees;

public partial class EmployeesController
{
	/// <summary>
	/// Get a single employee
	/// </summary>
	/// <param name="id">Primary key</param>
	/// <returns></returns>
	[HttpGet]
	[Route("{id}")]
	public async Task<IActionResult> GetEmployee(int id)
	{
		return await _employeeBll.GetEmployeeAsync(id);
	}
}