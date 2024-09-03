using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Employees;

public partial class EmployeesController
{
	/// <summary>
	/// Remove employee
	/// </summary>
	/// <param name="id">Primary key</param>
	/// <returns></returns>
	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> RemoveEmployee(int id)
	{
		return await _employeeBll.RemoveEmployeeAsync(id);
			
	}
}